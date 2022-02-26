using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [DisplayName ("Full Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Int64 Contact { get; set; }
        [ForeignKey ("Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Email { get; set; }
        [DisplayName ("Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [DisplayName("Join Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime JoinDate  { get; set; }
        [ForeignKey ("Salary")]
        [Required]
        public int SalaryId { get; set; }
        public Salary Salary { get; set;  }

    }
}
