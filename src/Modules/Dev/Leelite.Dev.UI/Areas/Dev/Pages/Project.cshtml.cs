using System.Text;

using Leelite.Core.Module;
using Leelite.Dev.Generator.Projects;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leelite.Dev.UI.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly ModuleOptions _moduleOptions;
        private readonly ILogger<ProjectModel> _logger;

        public StringBuilder Logs { get; set; }

        public ProjectModel(IOptions<ModuleOptions> moduleOptions, ILogger<ProjectModel> logger)
        {
            _moduleOptions = moduleOptions.Value;
            _logger = logger;
        }

        [BindProperty]
        public ProjectInfo Info { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var generater = new ProjectGenerator(Info, _moduleOptions);

            generater.Init();

            generater.Generating();

            Logs = generater.Logs;

            return Page();
        }
    }
}
