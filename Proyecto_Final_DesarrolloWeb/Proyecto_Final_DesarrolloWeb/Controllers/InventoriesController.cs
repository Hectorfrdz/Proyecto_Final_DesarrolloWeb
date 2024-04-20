using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;
using System.Diagnostics.Metrics;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var datos = _context.Inventories.Include(i => i.Product).Include(i => i.Warehouse).ToList();
            return View(datos);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _context.Inventories.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //Http Get Create
        public IActionResult Create()
        {
            ViewData["Product_ID"] = new SelectList(_context.Products, "product_id", "product_name");
            ViewData["Warehouse_ID"] = new SelectList(_context.Warehouses, "Warehouse_Id", "Warehouse_Name");
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inventories inventories)
        {
            if (ModelState.IsValid)
            {
                _context.Inventories.Add(inventories);
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
            var periodo = _context.Inventories.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["Product_ID"] = new SelectList(_context.Products, "product_id", "product_name",periodo);
            ViewData["Warehouse_ID"] = new SelectList(_context.Warehouses, "Warehouse_Id", "Warehouse_Name",periodo);
            return View(periodo);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inventories product)
        {
            if (ModelState.IsValid)
            {
                _context.Inventories.Update(product);
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
            var periodo = _context.Inventories.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["Product_ID"] = new SelectList(_context.Products, "product_id", "product_name", periodo);
            ViewData["Warehouse_ID"] = new SelectList(_context.Warehouses, "Warehouse_Id", "Warehouse_Name", periodo);
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
