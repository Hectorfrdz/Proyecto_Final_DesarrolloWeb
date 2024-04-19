using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;
using System.Diagnostics.Metrics;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class WarehousesController : Controller
    {
        // GET: WarehousesController
        private readonly ApplicationDbContext _context;

        public WarehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var datos = _context.Warehouses.Include(c => c.Locations).ToList();
            return View(datos);
        }

        // DETAIL: warehous
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var warehous = _context.Warehouses.Include(c => c.Locations).FirstOrDefault(c => c.Warehouse_Id == id);

            if (warehous == null)
            {
                return NotFound();
            }

            return View(warehous);
        }

        //Http Get Create
        public IActionResult Create()
        {
            ViewData["LOCATION_ID"] = new SelectList(_context.Locations, "LOCATION_ID", "ADDRESS");
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Warehouses Warehouses)
        {
            _context.Warehouses.Add(Warehouses);
            _context.SaveChanges();

            TempData["mensaje"] = "La warehous se guardo correctamente";
            return RedirectToAction("Index");
        }


        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["Location_ID"] = new SelectList(_context.Locations, "LOCATION_ID", "ADDRESS", warehouse);
            return View(warehouse);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Warehouses warehous)
        {
            _context.Warehouses.Update(warehous);
            _context.SaveChanges();

            TempData["mensaje"] = "La warehous se ha actualizado correctamente";
            return RedirectToAction("Index");
        }



        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var periodo = _context.Warehouses.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Warehouses warehous)
        {
            if (warehous == null)
            {
                return NotFound();
            }
            _context.Warehouses.Remove(warehous);
            _context.SaveChanges();

            TempData["mensaje"] = "La warehous se ha eliminado correctamente";
            return RedirectToAction("Index");


        }
    }
}
