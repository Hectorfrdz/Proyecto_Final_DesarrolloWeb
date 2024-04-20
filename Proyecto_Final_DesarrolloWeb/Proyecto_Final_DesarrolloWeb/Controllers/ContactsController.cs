using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class ContactsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _context.Contacts.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //Http Get Create
        public IActionResult Create()
        {
            ViewData["Customer_ID"] = new SelectList(_context.Customers, "CUSTOMER_ID", "NAME");
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contacts products)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(products);
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
            ViewData["Customer_ID"] = new SelectList(_context.Customers, "CUSTOMER_ID", "NAME",periodo);
            return View(periodo);
        }


        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contacts product)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(product);
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
            var periodo = _context.Contacts.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["Customer_ID"] = new SelectList(_context.Customers, "CUSTOMER_ID", "NAME", periodo);
            return View(periodo);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Contacts product)
        {
            if (product == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(product);
            _context.SaveChanges();

            TempData["mensaje"] = "El producto se ha eliminado correctamente";
            return RedirectToAction("Index");


        }
    }
}
