using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using EmployeeManagementSystem.Models.Repository.Interface;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly ISalaryRepository _salaryRepo;
        public EmployeesController( IEmployeeRepository employeeRepo, ISalaryRepository salaryRepo, IDepartmentRepository departmentRepo) 
        {
            _departmentRepo = departmentRepo;
            _salaryRepo = salaryRepo;
            _employeeRepo = employeeRepo;   
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            await _departmentRepo.GetDepartments();
            await _salaryRepo.GetSalaries();
            return View(await _employeeRepo.GetEmployees());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.Details(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name");
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Address,Contact,DepartmentId,Email,DOB,JoinDate,SalaryId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepo.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", employee.DepartmentId);
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Name", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.FindEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", employee.DepartmentId);
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages", employee.SalaryId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Address,Contact,DepartmentId,Email,DOB,JoinDate,SalaryId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepo.Edit(employee);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["DepartmentId"] = new SelectList(await _departmentRepo.GetDepartments(), "DepartmentId", "Name", employee.DepartmentId);
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepo.FindEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeRepo.FindEmployee(id);
            await _employeeRepo.Delete(employee);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return EmployeeExists(id);
        }
    }
}
