using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    [Authorize(Roles = "admin,Admin,Administrador")]
    public class RoleController : Controller
    {
        private readonly RoleRepository _roleRepository;

        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            var roleList = _roleRepository.GetAll();
            return View(roleList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var role = _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.Add(roleModel);
                return RedirectToAction(nameof(Index));
            }

            return View(roleModel);
        }

        public IActionResult Edit(int id)
        {
            var role = _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.Update(roleModel);
                return RedirectToAction(nameof(Index));
            }

            return View(roleModel);
        }

        public IActionResult Delete(int id)
        {
            var role = _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RoleModel roleModel)
        {
            _roleRepository.Delete(roleModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
