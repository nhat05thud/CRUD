using EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("EmployeeContext")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
