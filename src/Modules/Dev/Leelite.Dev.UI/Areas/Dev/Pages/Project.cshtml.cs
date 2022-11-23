using System.Text;
using Leelite.Modules.Dev.Generator.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Dev.UI.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public StringBuilder Logs { get; set; }

        public ProjectModel(ILogger<IndexModel> logger)
        {
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

            var generater = new ProjectGenerator(Info);

            generater.Init();

            generater.Generating();

            Logs = generater.Logs;

            return Page();
        }
    }
}
