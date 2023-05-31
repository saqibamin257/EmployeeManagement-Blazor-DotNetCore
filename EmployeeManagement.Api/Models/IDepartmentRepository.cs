using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int id);
    }
}
