using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private EmployeeManagementSystemDbContext _dbContext;
        public DepartmentRepository(EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Department> Details(int? id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<int> Edit(Department department)
        {
             _dbContext.Departments.Update(department);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Department> FindDepartment(int? id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
