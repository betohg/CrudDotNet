using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCruds.Data;
using ProyectoFinalCruds.Models;

namespace ProyectoFinalCruds.Controllers
{
    public class IventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }




        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var query = from i in _context.inventories
                        join p in _context.products on i.PRODUCT_ID equals p.PRODUCT_ID
                        join w in _context.warehouses on i.WAREHOUSE_ID equals w.WAREHOUSE_ID
                        orderby i.PRODUCT_ID
                        select new
                        {
                            ProductId = i.PRODUCT_ID,
                            WarehouseId = i.WAREHOUSE_ID,
                            Quantity = i.QUANTITY
                        };

            var paginatedCustomers = query.Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToList();

            int totalCustomers = _context.inventories.Count();
            int totalPages = (int)Math.Ceiling((double)totalCustomers / pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(paginatedCustomers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.inventories.FirstOrDefault(c => c.PRODUCT_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Iventories inventories)
        {
            if (ModelState.IsValid)
            {
                _context.inventories.Add(inventories);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(inventories);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var cust = _context.inventories.Find(id);
            return View(cust);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Iventories inventories)
        {
            if (ModelState.IsValid)
            {
                _context.inventories.Update(inventories);
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

            var customer = _context.inventories.FirstOrDefault(c => c.PRODUCT_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var customer = _context.inventories.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.inventories.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
