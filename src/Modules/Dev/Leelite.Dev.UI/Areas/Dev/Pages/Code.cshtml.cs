using System.Text;
using Leelite.Modules.Dev.Generator.Codes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Dev.UI.Pages
{
    public class CodeModel : PageModel
    {
        private readonly ILogger<CodeModel> _logger;

        public StringBuilder Logs { get; set; }

        public CodeModel(ILogger<CodeModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public AggregateInfo Info { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var generater = new CodeGenerator(Info);

            generater.Init();

            generater.Generating();

            Logs = generater.Logs;

            return Page();
        }
    }
}
