using System.ComponentModel.DataAnnotations;
using System.Net;

using Leelite.Application.Settings;
using Leelite.AspNetCore.Mvc.RazorPages;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Interfaces;
using Leelite.FileStorage.Options;
using Leelite.FileStorage.Utility;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.FileStorage.Pages
{
    public class SingleFileUploadModel : UserPageModel
    {
        private readonly IFileItemService _service;
        private readonly FileStorageOptions _filesOptions;
        private readonly string[] _permittedExtensions = [".txt"];

        public SingleFileUploadModel(IFileItemService service, ISettingManager settingManage)
        {
            _service = service;
            _filesOptions = settingManage.GetApplicationOptions<FileStorageOptions>();
        }

        [BindProperty]
        public SingleFileUploadInput FileUpload { get; set; }

        public string Result { get; private set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostUploadAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            // 不要相信客户端发送的文件名。
            // 要显示文件名，请对该值进行HTML编码。
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                FileUpload.FormFile.FileName);

            // 检查文件的长度。
            // 此检查不会捕获只有BOM作为内容的文件。
            if (FileUpload.FormFile.Length == 0)
            {
                ModelState.AddModelError(FileUpload.FormFile.Name,
                    $"File ({trustedFileNameForDisplay}) is empty.");
            }

            if (FileUpload.FormFile.Length > _filesOptions.FileSizeLimit)
            {
                var megabyteSizeLimit = _filesOptions.FileSizeLimit / 1048576;
                ModelState.AddModelError(FileUpload.FormFile.Name,
                    $"File ({trustedFileNameForDisplay}) exceeds " +
                    $"{megabyteSizeLimit:N1} MB.");
            }

            var formFileContent = Array.Empty<byte>();

            try
            {
                using var memoryStream = new MemoryStream();
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Check the content length in case the file's only
                // content was a BOM and the content is actually
                // empty after removing the BOM.
                if (memoryStream.Length == 0)
                {
                    ModelState.AddModelError(FileUpload.FormFile.Name,
                        $"File ({trustedFileNameForDisplay}) is empty.");
                }

                if (!FileHelpers.IsValidFileExtensionAndSignature(
                    FileUpload.FormFile.FileName, memoryStream, _permittedExtensions))
                {
                    ModelState.AddModelError(FileUpload.FormFile.Name,
                        $"File ({trustedFileNameForDisplay}) file " +
                        "type isn't permitted or the file's signature " +
                        "doesn't match the file's extension.");
                }
                else
                {
                    formFileContent = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(FileUpload.FormFile.Name,
                    $"File ({trustedFileNameForDisplay}) upload failed. " +
                    $"Please contact the Help Desk for support. Error: {ex.HResult}");
                // Log the exception
            }

            // Perform a second check to catch ProcessFormFile method
            // violations. If any validation check fails, return to the
            // page.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            // **警告！**
            // 在下面的例子中，在没有扫描文件内容的情况下保存文件。
            // 在大多数生产场景中，在使文件可供下载或供其他系统使用之前，会在文件上使用防病毒 / 防恶意软件扫描器API。
            // 欲了解更多信息，请参阅此示例所附带的主题。

            using (var memoryStream = new MemoryStream(formFileContent))
            {
                var request = new FileItemCreateRequest()
                {
                    Name = FileUpload.FormFile.FileName,
                    Length = FileUpload.FormFile.Length,
                    ContentType = FileUpload.FormFile.ContentType,
                    FileStream = memoryStream
                };

                await _service.CreateAsync(request);
            }

            return RedirectToPage("./Index");
        }
    }

    public class SingleFileUploadInput
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
