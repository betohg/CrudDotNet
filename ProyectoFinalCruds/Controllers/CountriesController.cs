using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCruds.Data;
using ProyectoFinalCruds.Models;

namespace ProyectoFinalCruds.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }




        public ActionResult Index(int? page)
        {
            IEnumerable<Countries> listaCustomers = _context.countries;
            return View(listaCustomers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.countries.FirstOrDefault(c => c.COUNTRY_ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Countries countries)
        {
            if (ModelState.IsValid)
            {
                _context.countries.Add(countries);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(countries);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var cust = _context.countries.Find(id);
            return View(cust);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Countries countries)
        {
            if (ModelState.IsValid)
            {
                _context.countries.Update(countries);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.countries.FirstOrDefault(c => c.COUNTRY_ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var contact = _context.countries.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.countries.Remove(contact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
