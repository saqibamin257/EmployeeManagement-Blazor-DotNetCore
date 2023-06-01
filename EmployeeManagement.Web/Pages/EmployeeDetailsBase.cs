using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase: ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();
        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;


        [Parameter]
        public string Id { get; set;}

        protected async override Task OnInitializedAsync()
        {
            // If Id value is not supplied in the URL, use the value 1
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e) 
        {
            Coordinates = $"X={e.ClientX} Y={e.ClientY}";
        }

        protected void Button_Click() 
        {
            if(ButtonText == "Hide Footer") 
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else 
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }


    }
}
