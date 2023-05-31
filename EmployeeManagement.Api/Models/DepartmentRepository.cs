using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments.ToList();
        }
        public Department GetDepartmentById(int DepartmentId)
        {
            return appDbContext.Departments.FirstOrDefault(d => d.DepartmentId == DepartmentId);
        }        
    }
}
