using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
    public interface IVacancyRepository
    {
        Task<IEnumerable<Vacancy>> GetVacancies();
        Task<int> Create(Vacancy vacancy);
        Task<int> Edit(Vacancy vacancy);
        Task<int> Delete(Vacancy vacancy);
        Task<Vacancy> FindVacancy(int? id);
        Task<Vacancy> Details(int? id);
    }
}
