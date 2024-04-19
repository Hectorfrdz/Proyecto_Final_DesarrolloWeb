using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DesarrolloWeb.Data;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Controllers
{
    public class Product_CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Product_CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product_CategoriesController
        public IActionResult Index()
        {
            IEnumerable<Product_Categories> all_categories = _context.Product_Categories;

            return View(all_categories);
        }

        // GET: Product_CategoriesController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categories = _context.Product_Categories.Find(id);

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: Product_CategoriesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product_CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product_Categories category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Product_CategoriesController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Product_Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Product_CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product_Categories category)
        {
            if (ModelState.IsValid)
            {
                _context.Product_Categories.Update(category);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Product_CategoriesController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _context.Product_Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Product_CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product_Categories category)
        {
            if (category == null)
            {
                return NotFound();
            }

            _context.Product_Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
