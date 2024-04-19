using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Regions> listaRegiones = _context.Regions;
            return View(listaRegiones);
        }

        // DETAIL: Region
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var region = _context.Regions.Find(id);

            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        //Http Get Create
        public IActionResult Create()
        {

            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions regiones)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Add(regiones);
                _context.SaveChanges();

                TempData["mensaje"] = "La region se guardo correctamente";
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
            var periodo = _context.Regions.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions region)
        {
            if (ModelState.IsValid)
            {
                _context.Regions.Update(region);
                _context.SaveChanges();

                TempData["mensaje"] = "La region se ha actualizado correctamente";
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
            var periodo = _context.Regions.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Regions region)
        {
            if (region == null)
            {
                return NotFound();
            }
            _context.Regions.Remove(region);
            _context.SaveChanges();

            TempData["mensaje"] = "La region se ha eliminado correctamente";
            return RedirectToAction("Index");


        }

    }

}
