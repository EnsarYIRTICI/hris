using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace hris.Pages.PageModels
{
    public abstract class BreadcrumbPageModel : PageModel
    {
        public class BreadcrumbItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public List<BreadcrumbItem> Breadcrumbs { get; set; } = new List<BreadcrumbItem>();

        protected void AddBreadcrumb(string name, string url = null)
        {
            Breadcrumbs.Add(new BreadcrumbItem { Name = name, Url = url });
        }
    }
}
