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
    public class SalariesController : Controller
    {
        private readonly ISalaryRepository _salaryRepo;
        private readonly IDesignationRepository _designationRepo;

        public SalariesController(ISalaryRepository salaryRepo, IDesignationRepository designationRepo)
        {
            _salaryRepo = salaryRepo;
            _designationRepo = designationRepo;
            
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            await _designationRepo.GetDesignations();
            return View (await _salaryRepo.GetSalaries());
        }


        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _salaryRepo.Details(id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Designation"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary)
        {
            if (ModelState.IsValid)
            {
                await _salaryRepo.Create(salary);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name", salary.DesignationId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _salaryRepo.FindSalary(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name", salary.DesignationId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryId,Wages,DesignationId")] Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _salaryRepo.Edit(salary);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.SalaryId))
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
            ViewData["DesignationId"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name", salary.DesignationId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var salary = await _salaryRepo.FindSalary(id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await _salaryRepo.FindSalary(id);
            await  _salaryRepo.Delete(salary);
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
            return SalaryExists(id);
        }
    }
}
