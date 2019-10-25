using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndoRestaurant.Models;
using IndoRestaurant.Utils;

namespace IndoRestaurant.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IndoRestaurantModelContainer db = new IndoRestaurantModelContainer();

        // GET: Home
        public ActionResult Index(string message = null)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Staff");
            }
           
            if (message == "1")
            {
                ViewBag.Message = new string[] { "Booking request has been submited, You will receive a confirmation email soon", "success" };
            }
            else if (message == "2")
            {
                ViewBag.Message = new string[] { "Thankyou for your review and comment. We hope can meet you again soon.", "success" };
            }
            
            var branches = db.Branches.ToList();
            ViewBag.Branches = branches;

            var menus = db.Menus.ToList();
            ViewBag.Menus = menus;

            return View();
        }

        // POST: Home/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Date,Time,Note,Persons,Email,FullName,Telephone,WaitingList,BranchId")] BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                bookingRequest.TransactionDate = DateTime.Now;
                db.BookingRequests.Add(bookingRequest);
                db.SaveChanges();

                var branch = db.Branches.Find(bookingRequest.BranchId);

                string subject = "Your booking request will be arranged";
                string contents = "Booking confirmation: <br /> " +
                    "Branch: " + branch.Name + " (" + branch.Address + ", tel: " + branch.Telephone + ")<br />" +
                    "Schedule: " + bookingRequest.Date.ToString("dd/MM/yyyy") + ", " + bookingRequest.Time + "<br/>" +
                    "We are arranging your request. We will send you a confirmation email soon as possible.";

                EmailSender es = new EmailSender();
                es.Send(bookingRequest.Email, subject, contents);

                return RedirectToAction("Index", new { message = 1 });
            }
            var branches = db.Branches.ToList();
            ViewBag.Branches = branches;

            var menus = db.Menus.ToList();
            ViewBag.Menus = menus;
            return View(bookingRequest);
        }
    }
}
