using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeManagementSystemDbContext : IdentityDbContext
    {
        public EmployeeManagementSystemDbContext( DbContextOptions<EmployeeManagementSystemDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Designation> Designations { get; set; }

    }
}
