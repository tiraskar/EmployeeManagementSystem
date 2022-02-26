using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Repository.Interface;

namespace EmployeeManagementSystem.Controllers
{
    public class LeavesController : Controller
    {
        private readonly ILeaveRepository _leaveRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public LeavesController(ILeaveRepository leaveRepo, IDepartmentRepository departmentRepo, IEmployeeRepository employeeRepo)
        {
            _leaveRepo = leaveRepo;
            _departmentRepo = departmentRepo;
            _employeeRepo = employeeRepo;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            await _employeeRepo.GetEmployees();
            await _departmentRepo.GetDepartments();
            return View (await _leaveRepo.GetLeaves());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _employeeRepo.Details(id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // GET: Leaves/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name");
            ViewData["EmployeeId"] = new SelectList(await _employeeRepo.GetEmployees(), "EmployeeId", "Name");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,DepartmentId,Days")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                await _leaveRepo.Create(leave);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", leave.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(await _employeeRepo.GetEmployees(), "EmployeeId", "Name", leave.EmployeeId);
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _leaveRepo.FindLeave(id);
            if (leave == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", leave.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(await _employeeRepo.GetEmployees(), "EmployeeId", "Name", leave.EmployeeId);
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,DepartmentId,Days")] Leave leave)
        {
            if (id != leave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveRepo.Edit(leave);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveExists(leave.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", leave.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(await _employeeRepo.GetEmployees(), "EmployeeId", "Name", leave.EmployeeId);
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _leaveRepo.FindLeave(id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leave = await _leaveRepo.FindLeave(id);
            await _leaveRepo.Delete(leave);
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveExists(int id)
        {
            return LeaveExists(id);
        }
    }
}
