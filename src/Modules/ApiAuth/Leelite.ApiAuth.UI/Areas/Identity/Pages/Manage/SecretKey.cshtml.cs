using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.AspNetCore.Mvc.RazorPages;
using Leelite.Framework.Data.Query.Paging;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Identity.Pages.Manage
{
    public class SecretKeyModel : AdminPageModel
    {
        private readonly IApiKeyService _apiKeyService;

        public SecretKeyModel(
            IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        [BindProperty(SupportsGet = true)]
        public int page { get; set; }

        public PageList<ApiKeyDto> PageList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (UserId == 0)
            {
                return NotFound($"Unable to load user with ID '{UserId}'.");
            }

            var query = new ApiKeyQueryParameter();

            query.UserId = UserId;
            query.Pager.Page = page;

            PageList = await _apiKeyService.GetPageListAsync(query);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string key)
        {
            if (UserId == 0)
            {
                return NotFound($"Unable to load user with ID '{UserId}'.");
            }

            var apiKey = await _apiKeyService.GetApiKeyAsync(key);

            if (UserId != apiKey.UserId)
            {
                return NotFound($"Unable to load SecretKey with ID '{key}'.");
            }

            await _apiKeyService.DeleteAsync(apiKey.Id);

            return RedirectToPage();
        }
    }
}
