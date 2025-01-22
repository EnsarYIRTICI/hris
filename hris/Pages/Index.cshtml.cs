using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages
{
    public class IndexModel : PageModel
    {
        public string Title { get; set; } = "Dashboard";
        public string Message { get; set; } = "Hello from Hris!";

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
