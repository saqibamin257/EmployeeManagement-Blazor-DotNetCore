using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Employee>> GetEmployees() 
        {
            return await appDbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int Id) 
        {
           return await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Id);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)         
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<Employee> AddEmployee(Employee employee) 
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        

        public async Task<Employee> UpdateEmployee(Employee employee) 
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)             
            {
                result.FirstName=employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                result.DepartmentId = employee.DepartmentId;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.PhotoPath = employee.PhotoPath;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> DeleteEmployee(int Id)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Id);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
