using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Identity.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Leelite.Web.Areas.Identity.Pages.Manage
{
    public class SecretKeyModel : PageModel
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
            var userId = User.GetUserId<long>();
            if (userId == 0)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var query = new ApiKeyQueryParameter();

            query.UserId = userId;
            query.Pager.Page = page;

            PageList = await _apiKeyService.GetPageListAsync(query);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string key)
        {
            var userId = User.GetUserId<long>();
            if (userId == 0)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var apiKey = await _apiKeyService.GetApiKeyAsync(key);

            if (userId != apiKey.UserId)
            {
                return NotFound($"Unable to load SecretKey with ID '{key}'.");
            }

            await _apiKeyService.DeleteAsync(apiKey.Id);

            return RedirectToPage();
        }
    }
}
