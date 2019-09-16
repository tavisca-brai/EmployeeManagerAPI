using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Model
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ManagersId { get; set; }
    }
}
