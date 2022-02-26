using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
   public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetSalaries();
        Task<int> Create(Salary salary);
        Task<int> Edit(Salary salary);
        Task<int> Delete(Salary salary);
        Task<Salary> FindSalary(int? id);
        Task<Salary> Details(int? id);
    }
}
