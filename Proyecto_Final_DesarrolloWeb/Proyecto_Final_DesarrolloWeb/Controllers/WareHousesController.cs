using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

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

        public IActionResult Index()
        {
            IEnumerable<Warehouses> listaWarehouses = _context.Warehouses;
            return View(listaWarehouses);
        }

        // DETAIL: warehous
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var warehous = _context.Warehouses.Find(id);

            if (warehous == null)
            {
                return NotFound();
            }

            return View(warehous);
        }

        //Http Get Create
        public IActionResult Create()
        {

            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Warehouses Warehouses)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Add(Warehouses);
                _context.SaveChanges();

                TempData["mensaje"] = "La warehous se guardo correctamente";
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
            var periodo = _context.Warehouses.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Warehouses warehous)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Update(warehous);
                _context.SaveChanges();

                TempData["mensaje"] = "La warehous se ha actualizado correctamente";
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
