using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        [DisplayName("Employee Name")]
        [Required]
        public int EmployeeId { get; set; }
        public Employee Name{ get; set; }
        [ForeignKey("Department")]
        [DisplayName("Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [DisplayName("Days of Leave")]
        public int Days { get; set;  }

    }
}
