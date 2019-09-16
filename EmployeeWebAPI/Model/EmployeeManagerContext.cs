using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Model
{
    public class EmployeeManagerContext : DbContext
    {
        public EmployeeManagerContext(DbContextOptions<EmployeeManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
