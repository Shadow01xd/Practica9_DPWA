using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    [Authorize]
    public class StaffCategoryController : Controller
    {
        private readonly StaffCategoryRepository _staffCategoryRepository;

        public StaffCategoryController(StaffCategoryRepository staffCategoryRepository)
        {
            _staffCategoryRepository = staffCategoryRepository;
        }

        public IActionResult Index()
        {
            var categoryList = _staffCategoryRepository.GetAll();
            return View(categoryList);
        }

        public IActionResult Details(int id)
        {
            var category = _staffCategoryRepository.GetById(id);
            if (category == null) return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffCategoryModel staffCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _staffCategoryRepository.Add(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }

            return View(staffCategoryModel);
        }

        public IActionResult Edit(int id)
        {
            var category = _staffCategoryRepository.GetById(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffCategoryModel staffCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _staffCategoryRepository.Update(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }

            return View(staffCategoryModel);
        }

        public IActionResult Delete(int id)
        {
            var category = _staffCategoryRepository.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StaffCategoryModel staffCategoryModel)
        {
            _staffCategoryRepository.Delete(staffCategoryModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
