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

            // ��Ҫ���ſͻ��˷��͵��ļ�����
            // Ҫ��ʾ�ļ�������Ը�ֵ����HTML���롣
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                FileUpload.FormFile.FileName);

            // ����ļ��ĳ��ȡ�
            // �˼�鲻�Ჶ��ֻ��BOM��Ϊ���ݵ��ļ���
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

            // **���棡**
            // ������������У���û��ɨ���ļ����ݵ�����±����ļ���
            // �ڴ�������������У���ʹ�ļ��ɹ����ػ�����ϵͳʹ��֮ǰ�������ļ���ʹ�÷����� / ���������ɨ����API��
            // ���˽������Ϣ������Ĵ�ʾ�������������⡣

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
