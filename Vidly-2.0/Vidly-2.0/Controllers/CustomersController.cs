﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2._0.Models;

namespace Vidly_2._0.Controllers
{
    public class CustomersController : Controller
    {

        // GET: Customers
        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }
        // GET: Customers/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Marry Williams"}
            };
        }

    }
}