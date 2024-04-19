using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace App_asp_net_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            IEnumerable<Customers> all_customers = _context.Customers;

            return View(all_customers);
        }

        // DETAIL: Customers
        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // CREATE: Customers
        public IActionResult Create()
        {
            return View();
        }

        // STORE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // EDIT: Customers
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // UPDATE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customers);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // DELETE: Customers
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // DELETE: Customers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Customers customer)
        {
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

