using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
   public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<int> Create(Employee employee);
        Task<int> Edit(Employee employee);
        Task<int> Delete(Employee employee);
        Task<Employee> FindEmployee(int? id);
        Task<Employee> Details(int? id);
    }
}
