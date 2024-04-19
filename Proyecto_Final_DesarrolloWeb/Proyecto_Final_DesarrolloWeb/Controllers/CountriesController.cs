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

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyCountryId(string COUNTRY_ID)
        {
            var exists = _context.Countries.Any(c => c.COUNTRY_ID == COUNTRY_ID);
            return Json(!exists);
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

            // Incluye la propiedad de navegación Regions al cargar el país desde la base de datos
            var country = _context.Countries.Include(c => c.Regions).FirstOrDefault(c => c.COUNTRY_ID == id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // CREATE: countrys
        public IActionResult Create()
        {
            ViewData["Region_ID"] = new SelectList(_context.Regions, "REGION_ID", "REGION_NAME");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Countries country)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(country);
                _context.SaveChanges();

                return RedirectToAction("Index");
            //}

            //// Si la validación del modelo falla, retorna la vista con el modelo
            //return View(country);
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
            ViewData["Region_ID"] = new SelectList(_context.Regions, "REGION_ID", "REGION_NAME", country);
            return View(country);
        }

        // UPDATE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries countrys)
        {
            _context.Countries.Update(countrys);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
