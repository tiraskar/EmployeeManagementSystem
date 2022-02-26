using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public DesignationRepository(EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(Designation designation)
        {
            await _dbContext.Designations.AddAsync(designation);
            return await _dbContext.SaveChangesAsync(); 
        }

        public async Task<int> Delete(Designation designation)
        {
            _dbContext.Designations.Remove(designation);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Designation> Details(int? id)
        {
            return await _dbContext.Designations.FindAsync(id);
        }

        public async Task<int> Edit(Designation designation)
        {
            _dbContext.Designations.Update(designation);
            return await _dbContext.SaveChangesAsync(); 
        }

        public async Task<Designation> FindDesignation(int? id)
        {
            return await _dbContext.Designations.FindAsync(id);
        }

        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            return await _dbContext.Designations.ToListAsync();
        }
    }
}
