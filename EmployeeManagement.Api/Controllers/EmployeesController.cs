using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees() 
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees()); //ok send back code 200 automatically.
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int Id) 
        {
            try
            {
                var result = await employeeRepository.GetEmployeeById(Id);
                if(result == null) 
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }    
        
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee) 
        {            
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);
                if(emp != null) 
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }
                var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { Id = createdEmployee.EmployeeId }, createdEmployee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
        
        [HttpPut("{Id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int Id,Employee employee) 
        {
            try
            {
                if (Id != employee.EmployeeId)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var emp = await employeeRepository.GetEmployeeById(Id);

                if (emp == null)
                {
                    return NotFound($"Employee with Id {Id} not found.");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }            
        }
        
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int Id) 
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployeeById(Id);
                if(employeeToDelete == null) 
                {
                    return NotFound($"Employee with Id {Id} not found.");
                }
                return await employeeRepository.DeleteEmployee(Id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Searching the Emp..");
            }
        }
    }
}
