
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await Task.Run(LoadEmployees);
            
        }
        private void LoadEmployees() 
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Saqib",
                LastName = "Amin",
                Email = "saqib@abc.com",
                DateOfBirth = new DateTime(1985, 10, 24),
                Gender = Gender.Male,
                DepartmentId =  1,
                PhotoPath = "images/john.png"
            };
            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Waqar",
                LastName = "Amin",
                Email = "waqar@abc.com",
                DateOfBirth = new DateTime(1983, 10, 24),
                Gender = Gender.Male,
                DepartmentId =  2,
                PhotoPath = "images/sam.jpg"
            };
            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Asima",
                LastName = "Amin",
                Email = "asima@abc.com",
                DateOfBirth = new DateTime(1989, 10, 24),
                Gender = Gender.Female,
                DepartmentId =  3,
                PhotoPath = "images/mary.png"
            };
            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Fatima",
                LastName = "Amin",
                Email = "fatma@abc.com",
                DateOfBirth = new DateTime(1980, 10, 24),
                Gender = Gender.Female,
                DepartmentId =  4,
                PhotoPath = "images/sara.png"
            };
            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}
