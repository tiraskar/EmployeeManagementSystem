using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        [DisplayName("Salary")]
        [Required]
        public int Wages { get; set; }
        [ForeignKey("Designation")]
        [Required]
        public int DesignationId { get; set;  }
        public Designation Designation { get; set; }

    }
}
