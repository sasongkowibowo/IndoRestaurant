using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndoRestaurant.Models;
using IndoRestaurant.Utils;

namespace IndoRestaurant.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CampaignsController : Controller
    {
        private IndoRestaurantModelContainer db = new IndoRestaurantModelContainer();

        // GET: Campaigns
        public ActionResult Index()
        {
            return View(db.Campaigns.ToList());
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: Campaigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Subject, string Content, HttpPostedFileBase AttachmentPath)
        {
            var emails = db.BookingRequests.Select(e => e.Email).Distinct().ToList();

            List<string> emailStrings = new List<string>();
            foreach (string listItem in emails)
            {
                emailStrings.Add(listItem);
            }

            string sendToList = string.Join(",", emailStrings);

            Campaign campaign = new Campaign();
            campaign.Subject = Subject;
            campaign.Content = Content;
            campaign.SendTo = sendToList;
            campaign.SendDate = DateTime.Now;
            campaign.AttachmentPath = null;
            string path = "";
            string fileName = "";
            try
            {
                if (AttachmentPath != null)
                {
                    string uniq = Guid.NewGuid().ToString("N");
                    fileName = Path.GetFileName(AttachmentPath.FileName);
                    path = Path.Combine(Server.MapPath("~/UploadedAttachments"), uniq + "_" + fileName);
                    AttachmentPath.SaveAs(path);
                    campaign.AttachmentPath = "\\AttachmentFiles\\" + uniq + "_" + fileName;
                }
            }
            catch (Exception)
            {

            }

            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();

                EmailSender es = new EmailSender();
                es.SendMultiple(emailStrings, campaign.Subject, campaign.Content, path, fileName);
                return RedirectToAction("Index");
            }

            return View(campaign);
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
