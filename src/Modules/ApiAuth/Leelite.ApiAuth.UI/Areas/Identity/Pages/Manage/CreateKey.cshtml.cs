using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Identity.Pages.Manage
{
    public class CreateKeyModel : AdminPageModel
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
            if (UserId == 0)
            {
                return NotFound($"Unable to load user with ID '{UserId}'.");
            }

            Input.UserId = UserId;
            Input.Claims = User.Claims.ToList();

            await _apiKeyService.CreateAsync(Input);

            return RedirectToPage("SecretKey");
        }
    }
}
