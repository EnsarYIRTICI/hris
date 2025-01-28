using hris.Pages.PageModels;


namespace hris.Pages.Employees.Edit
{
    public class IndexModel : BreadcrumbPageModel
    {

        public void OnGet()
        {
            AddBreadcrumb("Employees", "/employees");
            AddBreadcrumb("Edit");


        }
    }

  
}
