using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public LeaveRepository (EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(Leave leave)
        {
            await _dbContext.Leaves.AddAsync(leave);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Leave leave)
        {
            _dbContext.Leaves.Remove(leave);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Leave> Details(int? id)
        {
            return await _dbContext.Leaves.FindAsync(id);
        }

        public async Task<int> Edit(Leave leave)
        {
            _dbContext.Leaves.Update(leave);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Leave> FindLeave(int? id)
        {
            return await _dbContext.Leaves.FindAsync(id);
        }
        public async Task<IEnumerable<Leave>> GetLeaves()
        {
            return await _dbContext.Leaves.ToListAsync();
        }
    }
}
