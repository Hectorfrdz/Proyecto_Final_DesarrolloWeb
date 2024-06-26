﻿using Microsoft.AspNetCore.Http;
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

        public ActionResult Index()
        {
            var datos = _context.Contacts.Include(c => c.Customers).ToList();
            return View(datos);
        }

        // DETAIL: Contacts
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Incluye la propiedad de navegación Customers al cargar el país desde la base de datos
            var country = _context.Contacts.Include(c => c.Customers).FirstOrDefault(c => c.CONTACT_ID == id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // CREATE: countrys
        public IActionResult Create()
        {
            ViewData["CUSTOMER_ID"] = new SelectList(_context.Customers, "CUSTOMER_ID", "NAME");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contacts country)
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

            var country = _context.Contacts.Find(id);

            if (country == null)
            {
                return NotFound();
            }
            ViewData["CUSTOMER_ID"] = new SelectList(_context.Customers, "CUSTOMER_ID", "NAME", country);
            return View(country);
        }

        // UPDATE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contacts countrys)
        {
            _context.Contacts.Update(countrys);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var country = _context.Contacts.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // DELETE: countrys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Contacts country)
        {
            if (country == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
