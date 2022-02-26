using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Vacancy
    {
        public int VacancyId { get; set; }
        [DisplayName("Title")]
        [Required]
        public string Name { get; set; }
        [ForeignKey("Designation")]
        [Required]
        public int DesignationId { get; set; }
        public Designation Designation{ get; set; }
        [Required]
        public string Experiecne { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set;  }
        [ForeignKey("Salary")]
        [Required]
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }

    }
}
