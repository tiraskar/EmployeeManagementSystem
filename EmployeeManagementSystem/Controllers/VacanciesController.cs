using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IVacancyRepository _vacancyRepo;
        private readonly ISalaryRepository _salaryRepo;
        private readonly IDesignationRepository _designationRepo;

        public VacanciesController( IVacancyRepository vacancyRepo, ISalaryRepository salaryRepo, IDesignationRepository designationRepo)
        {
            _vacancyRepo = vacancyRepo;
            _salaryRepo = salaryRepo;
            _designationRepo = designationRepo;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            await _salaryRepo.GetSalaries();
            await _designationRepo.GetDesignations();
            return View(await _vacancyRepo.GetVacancies());
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vacancy = await _vacancyRepo.Details(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public async Task< IActionResult> Create()
        {
            ViewData["Designation"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name");
            ViewData["Salary"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages");
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacancyId,Name,DesignationId,Experiecne,Qualification,Deadline,SalaryId")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                await _vacancyRepo.Create(vacancy);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList( await _designationRepo.GetDesignations(), "Id", "Name", vacancy.DesignationId) ;
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages", vacancy.SalaryId);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _vacancyRepo.FindVacancy(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Name", vacancy.DesignationId);
            ViewData["SalaryId"] = new SelectList(await _salaryRepo.GetSalaries(), "SalaryId", "Wages", vacancy.SalaryId) ;
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacancyId,Name,DesignationId,Experiecne,Qualification,Deadline,SalaryId")] Vacancy vacancy)
        {
            if (id != vacancy.VacancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await  _vacancyRepo.Edit(vacancy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.VacancyId))
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
            ViewData["DesignationId"] = new SelectList(await _designationRepo.GetDesignations(), "Id", "Id", vacancy.DesignationId);
            ViewData["SalaryId"] = new SelectList( await _salaryRepo.GetSalaries(), "SalaryId", "SalaryId", vacancy.SalaryId);
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _vacancyRepo.FindVacancy(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _vacancyRepo.FindVacancy(id);
            await _vacancyRepo.Delete(vacancy);
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return VacancyExists(id);
        }
    }
}
