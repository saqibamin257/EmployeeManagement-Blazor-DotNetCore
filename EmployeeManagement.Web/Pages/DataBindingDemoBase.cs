using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase: ComponentBase
    {
        protected string Name { get; set; } = "Ahmad";
        protected string Gender { get; set; } = "Male";

        protected string TextInput { get; set; } = string.Empty;
    }
}
