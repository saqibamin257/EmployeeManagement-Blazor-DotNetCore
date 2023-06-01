using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees() 
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }
        public async Task<Employee> GetEmployeeById(int Id) 
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{Id}");
        }
    }
}
