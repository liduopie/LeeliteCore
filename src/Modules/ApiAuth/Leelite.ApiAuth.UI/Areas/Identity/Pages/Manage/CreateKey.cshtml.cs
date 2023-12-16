using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.Identity.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Leelite.Web.Areas.Identity.Pages.Manage
{
    public class CreateKeyModel : PageModel
    {
        private readonly IApiKeyService _apiKeyService;

        public CreateKeyModel(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        [BindProperty]
        public ApiKeyCreateRequest Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.GetUserId<long>();
            if (userId == 0)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            Input.UserId = userId;
            Input.Claims = User.Claims.ToList();

            await _apiKeyService.CreateAsync(Input);

            return RedirectToPage("SecretKey");
        }
    }
}
