using CarInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress, string birthday, bool DUI, string speedingTickets, string carYear, string carMake, string carModel, string coverage)
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var customer = new Customer();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.EmailAddress = emailAddress;
                customer.DateOfBirth = Convert.ToDateTime(birthday);
                customer.DUI = DUI;
                customer.SpeedingTickets = Convert.ToInt32(speedingTickets);
                customer.CarYear = Convert.ToInt32(carYear);
                customer.CarMake = carMake;
                customer.CarModel = carModel;
                customer.Coverage = coverage;

                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View("CustomerQuote");
        }
    }
}