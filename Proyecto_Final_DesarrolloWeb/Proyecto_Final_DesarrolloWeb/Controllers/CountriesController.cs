using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;
using System.Diagnostics.Metrics;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var datos = _context.Countries.Include(c => c.Regions).ToList();
            return View(datos);
        }

        // DETAIL: Customers
        public IActionResult Details(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var country = _context.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // CREATE: countrys
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Countries country, string id)
        {

            if (ModelState.IsValid)
            {
                if (id == "add")
                {

                    await _context.Countries.AddAsync(country);
                    await _context.SaveChangesAsync();

                    TempData["mensaje"] = "El Pais se guardo correctamente";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Countries.Update(country);
                    await _context.SaveChangesAsync();

                    TempData["mensaje"] = "Cambios guardados correctamente";
                    return RedirectToAction(nameof(Index), new { id = "" });
                }
            }

            return View(country);
        }

        // EDIT: countrys
        public IActionResult Edit(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var country = _context.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // UPDATE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries countrys)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(countrys);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var country = _context.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // DELETE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Countries country)
        {
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
