using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Position { get; set; }
        public string Office { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
