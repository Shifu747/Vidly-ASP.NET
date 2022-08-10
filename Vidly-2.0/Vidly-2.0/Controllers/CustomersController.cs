using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2._0.Models;

namespace Vidly_2._0.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //to access db

        public CustomersController() //initialize constructor
        {
            _context = new ApplicationDbContext();
        }

        //dbcontext is disposable object . disposing
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ViewResult Index()
        {
            //.ToList executes the query
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        // GET: Customers/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

    }
}