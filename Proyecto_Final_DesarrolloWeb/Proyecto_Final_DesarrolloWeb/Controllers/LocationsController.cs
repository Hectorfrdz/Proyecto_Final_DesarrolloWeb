using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationsController
        public ActionResult Index()
        {
            var datos = _context.Locations.Include(c => c.Country).ToList();
            return View(datos);
        }

        // DETAIL: Customers
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Incluye la propiedad de navegación Regions al cargar el país desde la base de datos
            var location = _context.Locations.Include(c => c.Country).FirstOrDefault(c => c.LOCATION_ID == id);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // CREATE: locations
        public IActionResult Create()
        {
            ViewData["COUNTRY_ID"] = new SelectList(_context.Countries, "COUNTRY_ID", "COUNTRY_NAME");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Locations location)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(location);
            _context.SaveChanges();

            return RedirectToAction("Index");
            //}

            //// Si la validación del modelo falla, retorna la vista con el modelo
            //return View(location);
        }

        // EDIT: locations
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var location = _context.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }
            ViewData["COUNTRY_ID"] = new SelectList(_context.Countries, "COUNTRY_ID", "COUNTRY_NAME", location);
            return View(location);
        }

        // UPDATE: locations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Locations locations)
        {
            _context.Locations.Update(locations);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var location = _context.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // DELETE: locations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Locations location)
        {
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
