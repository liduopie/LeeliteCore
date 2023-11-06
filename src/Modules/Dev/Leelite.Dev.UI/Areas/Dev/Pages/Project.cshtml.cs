using System.Text;
using Leelite.Dev.Generator.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Leelite.Dev.UI.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly ILogger<ProjectModel> _logger;

        public StringBuilder Logs { get; set; }

        public ProjectModel(ILogger<ProjectModel> logger)
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
