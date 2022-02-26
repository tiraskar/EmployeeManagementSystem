using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public EmployeeRepository(EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<int> Create(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Details(int? id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<int> Edit(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> FindEmployee(int? id)
        {
            return await _dbContext.Employees.FindAsync(id);
            
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
