using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models.Repository.Interface
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetLeaves();
        Task<int> Create(Leave leave);
        Task<int> Edit(Leave leave);
        Task<int> Delete(Leave leave);
        Task<Leave> FindLeave(int? id);
        Task<Leave> Details(int? id);
    }
}
