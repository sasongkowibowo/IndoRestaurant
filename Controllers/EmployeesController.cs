using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using IndoRestaurant.Models;
using IndoRestaurant.Controllers;
using System.Web.Security;

namespace IndoRestaurant.Controllers
{

    public class EmployeesController : Controller
    {
        private IndoRestaurantModelContainer db = new IndoRestaurantModelContainer();

        // GET: Employees
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {

            var employees = db.Employees.Include(e => e.Branch);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FullName,Telephone,UserType,BranchId,Password")] Employee employee)
        {
            employee.LoginId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(employee);

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Staff");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", employee.BranchId);
            return View(employee);
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
