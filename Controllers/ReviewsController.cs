using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndoRestaurant.Models;
using Microsoft.AspNet.Identity;

namespace IndoRestaurant.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReviewsController : Controller
    {
        private IndoRestaurantModelContainer db = new IndoRestaurantModelContainer();

        // GET: Reviews
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            int branchId = db.Employees.Where(i => i.LoginId.Equals(userId)).Select(i => i.BranchId).SingleOrDefault();
            var reviews = db.Reviews.Where(b => b.BranchId == branchId);

            var sumMenu = db.Database.SqlQuery<int>("SELECT sum(dbo.Reviews.Menu) FROM dbo.Reviews WHERE " +
               "dbo.Reviews.BranchId =" + branchId).SingleOrDefault();

            var sumPlace = db.Database.SqlQuery<int>("SELECT sum(dbo.Reviews.Place)" +
             " FROM dbo.Reviews WHERE" +
             " dbo.Reviews.BranchId =" + branchId).SingleOrDefault();

            var sumService = db.Database.SqlQuery<int>("SELECT sum(dbo.Reviews.Service) FROM dbo.Reviews WHERE" +
              " dbo.Reviews.BranchId =" + branchId).SingleOrDefault();

            var sumBookingProcess = db.Database.SqlQuery<int>("SELECT sum(dbo.Reviews.BookingProcess) " +
                "FROM dbo.Reviews WHERE" +
              " dbo.Reviews.BranchId =" + branchId).SingleOrDefault();

            var numberOfRecords = db.Database.SqlQuery<int>("SELECT count(*) " +
                "FROM dbo.Reviews WHERE" +
             " dbo.Reviews.BranchId =" + branchId).SingleOrDefault();

            float avgMenu = (float)sumMenu / (float)numberOfRecords;
            ViewBag.AvgMenu = avgMenu;
            float avgPlace = (float)sumPlace / (float)numberOfRecords;
            ViewBag.AvgPlace = avgPlace;
            float avgService = (float)sumService / (float)numberOfRecords;
            ViewBag.AvgService = avgPlace;
            float avgBookingProcess = (float)sumBookingProcess / (float)numberOfRecords;
            ViewBag.AvgBookingProcess = avgBookingProcess;

            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [AllowAnonymous]
        // GET: Reviews/Create/5
        public ActionResult Create(string reviewCode)
        {
            if (reviewCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookingRequest = db.BookingRequests.Where(r => r.ReviewCode == reviewCode).FirstOrDefault();
            if (bookingRequest == null)
            {
                return HttpNotFound();
            }
            var review = db.Reviews.Where(b => b.BookingRequestId == bookingRequest.Id).FirstOrDefault();
            if (review != null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingRequest = bookingRequest;
            return View();
        }


        [AllowAnonymous]
        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Menu,Place,Service,BookingProcess,Comment,BranchId,BookingRequestId")] Review review)
        {
            review.ReviewDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { message = 2 });
            }

            var bookingRequest = db.BookingRequests.Find(review.BookingRequestId);
            ViewBag.BookingRequest = bookingRequest;
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
