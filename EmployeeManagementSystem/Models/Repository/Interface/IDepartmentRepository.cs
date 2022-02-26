using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<int> Create(Department department);
        Task<int> Edit(Department department);
        Task<int> Delete(Department department);
        Task<Department> FindDepartment(int? id);
        Task<Department> Details(int? id);
    }
}
