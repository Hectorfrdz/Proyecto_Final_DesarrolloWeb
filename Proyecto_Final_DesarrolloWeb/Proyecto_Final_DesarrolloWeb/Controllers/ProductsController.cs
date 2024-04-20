using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var datos = _context.Products.Include(c => c.product_categories).ToList();
            return View(datos);
        }

        // DETAIL: Products
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Incluye la propiedad de navegación Customers al cargar el país desde la base de datos
            var country = _context.Products.Include(c => c.product_categories).FirstOrDefault(c => c.PRODUCT_ID == id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // CREATE: countrys
        public IActionResult Create()
        {
            ViewData["CATEGORY_ID"] = new SelectList(_context.Product_Categories, "CATEGORY_ID", "CATEGORY_NAME");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products country)
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var country = _context.Products.Find(id);

            if (country == null)
            {
                return NotFound();
            }
            ViewData["CATEGORY_ID"] = new SelectList(_context.Product_Categories, "CATEGORY_ID", "CATEGORY_NAME", country);
            return View(country);
        }

        // UPDATE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products countrys)
        {
            _context.Products.Update(countrys);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var country = _context.Products.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // DELETE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products country)
        {
            if (country == null)
            {
                return NotFound();
            }

            _context.Products.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
