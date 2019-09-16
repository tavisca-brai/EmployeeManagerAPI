using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPI.Model;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManagerContext _context;
        public EmployeeController(EmployeeManagerContext context)
        {
            _context = context;
            if(_context.Employees.Count() == 0)
            {
                _context.Employees.Add(new Employee
                {
                    Name = "Vighnesh",
                    ManagersId = 1
                });

                _context.Employees.Add(new Employee
                {
                    Name = "Raunak",
                    ManagersId = 2
                });

                _context.Employees.Add(new Employee
                {
                    Name = "Ibraham",
                    ManagersId = 2
                });

                _context.Employees.Add(new Employee
                {
                    Name = "DJ",
                    ManagersId = 1
                });

                _context.Employees.Add(new Employee
                {
                    Name = "Deepak",
                    ManagersId = 3
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostTodoItem(Employee data)
        {
            _context.Employees.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployees), new { id = data.Id }, data);
        }
    }
}
