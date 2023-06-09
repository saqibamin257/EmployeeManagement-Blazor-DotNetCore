﻿using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee= await EmployeeService.GetEmployeeById(int.Parse(Id));            
        }
    }
}
