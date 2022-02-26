using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class SalaryRepository: ISalaryRepository
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public SalaryRepository (EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Salary salary)
        {
            await _dbContext.Salaries.AddAsync(salary);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Salary salary)
        {
            _dbContext.Salaries.Remove(salary);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Salary> Details(int? id)
        {
            return await _dbContext.Salaries.FindAsync(id);
        }

        public async Task<int> Edit(Salary salary)
        {
            _dbContext.Salaries.Update(salary);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Salary> FindSalary(int? id)
        {
            return await _dbContext.Salaries.FindAsync(id);
        }

        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            return await _dbContext.Salaries.ToListAsync();
        }
    }
}
