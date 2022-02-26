using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Implementation
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly EmployeeManagementSystemDbContext _dbContext;
        public VacancyRepository(EmployeeManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(Vacancy vacancy)
        {
            await _dbContext.Vacancies.AddAsync(vacancy);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Vacancy vacancy)
        {
            _dbContext.Vacancies.Remove(vacancy);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Vacancy> Details(int? id)
        {
            return await _dbContext.Vacancies.FindAsync(id);
        }

        public async Task<int> Edit(Vacancy vacancy)
        {
            _dbContext.Vacancies.Update(vacancy);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<Vacancy> FindVacancy(int? id)
        {
            return await _dbContext.Vacancies.FindAsync(id);
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies()
        {
            return await _dbContext.Vacancies.ToListAsync();
        }

        
    }
}
