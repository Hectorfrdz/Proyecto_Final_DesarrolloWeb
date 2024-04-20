using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;
using System.Diagnostics.Metrics;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //IEnumerable<Products> listaProductos = _context.Products;
            var datos = _context.Products.Include(c => c.Product_Categories).ToList();
            return View(datos);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //Http Get Create
        public IActionResult Create()
        {
            ViewData["Category_ID"] = new SelectList(_context.Product_Categories, "CATEGORY_ID", "CATEGORY_NAME");
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(products);
                _context.SaveChanges();

                TempData["mensaje"] = "El producto se guardo correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }


        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var periodo = _context.Products.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["Category_ID"] = new SelectList(_context.Product_Categories, "CATEGORY_ID", "CATEGORY_NAME",periodo);
            return View(periodo);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                TempData["mensaje"] = "El producto se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }



        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var periodo = _context.Products.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["Category_ID"] = new SelectList(_context.Product_Categories, "CATEGORY_ID", "CATEGORY_NAME", periodo);
            return View(periodo);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products product)
        {
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            TempData["mensaje"] = "El producto se ha eliminado correctamente";
            return RedirectToAction("Index");


        }

    
}
}
