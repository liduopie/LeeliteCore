using System.Text;

using Leelite.AspNetCore.Mvc.RazorPages;
using Leelite.Core.Module;
using Leelite.Dev.Generator.Codes;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leelite.Web.Areas.Dev.Pages
{
    public class CodeModel : DevPageModel
    {
        private readonly ModuleOptions _moduleOptions;
        private readonly ILogger<CodeModel> _logger;

        public StringBuilder Logs { get; set; }

        public CodeModel(IOptions<ModuleOptions> moduleOptions, ILogger<CodeModel> logger)
        {
            _moduleOptions = moduleOptions.Value;
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

            var generater = new CodeGenerator(Info, _moduleOptions);

            generater.Init();

            generater.Generating();

            Logs = generater.Logs;

            return Page();
        }
    }
}
