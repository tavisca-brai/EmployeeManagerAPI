using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebAPI.Model;
using System;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly EmployeeManagerContext _context;
        public ManagerController(EmployeeManagerContext context)
        {
            _context = context;
            if (_context.Managers.Count() == 0)
            {
                _context.Managers.Add(new Manager
                {
                    Name = "Bhanu"
                });
                _context.Managers.Add(new Manager
                {
                    Name = "Omkar"
                }); _context.Managers.Add(new Manager
                {
                    Name = "Gogawale"
                });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManagerById(long id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }

        [HttpGet("{id}/Employee")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByManagerId(long id)
        {
            var employees = (await _context.Employees.ToListAsync())
                .Where(s => s.ManagersId == id)
                .Select(s => s.Id)
                .ToList();

            return (await _context.Employees.ToListAsync())
                    .Where(s => employees.Contains(s.Id))
                    .ToList();
        }
    }
}
