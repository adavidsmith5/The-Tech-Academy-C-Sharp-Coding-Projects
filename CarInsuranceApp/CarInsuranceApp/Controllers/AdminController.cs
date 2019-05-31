using CarInsuranceApp.Models;
using CarInsuranceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var customers = (from c in db.Customers
                                where c.Quote == null
                                select c).ToList();
                var customerVMs = new List<CustomerVM>();
                foreach (var customer in customers)
                {
                    double quote = 50;
                    var currentYear = DateTime.Now.Year;
                    var age = currentYear - Convert.ToDateTime(customer.DateOfBirth).Year;
                    if (age < 18)
                    {
                        quote += 100;
                    }
                    else if (age < 25 || age > 100)
                    {
                        quote += 25;
                    }
                    if (customer.CarYear < 2000 || customer.CarYear > 2015)
                    {
                        quote += 25;
                    }
                    if (customer.CarMake == "Porsche")
                    {
                        quote += 25;
                        if (customer.CarModel == "911 Carrera")
                        {
                            quote += 25;
                        }
                    }
                    quote += 10 * (double)customer.SpeedingTickets;
                    if (customer.DUI == true)
                    {
                        quote *= 1.25;
                    }
                    if (customer.Coverage == "full")
                    {
                        quote *= 1.5;
                    }
                    customer.Quote = (decimal)quote;


                    var customerVM = new CustomerVM();
                    customerVM.FirstName = customer.FirstName;
                    customerVM.LastName = customer.LastName;
                    customerVM.EmailAddress = customer.EmailAddress;
                    customerVM.Quote = (decimal)customer.Quote;

                    customerVMs.Add(customerVM);
                }
                return View(customerVMs);
            }
        }
    }
}