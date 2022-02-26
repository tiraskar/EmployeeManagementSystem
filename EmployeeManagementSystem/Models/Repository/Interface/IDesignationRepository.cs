using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetDesignations();
        Task<int> Create(Designation designation);
        Task<int> Edit(Designation designation);
        Task<int> Delete(Designation designation);
        Task<Designation> FindDesignation(int? id);
        Task<Designation> Details(int? id);
    }
}
