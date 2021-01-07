using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserModelling.Data;
using UserModelling.Models;

namespace UserModelling.Controllers
{
    public class EventOrganisersController : Controller
    {
        private UserModellingContext db = new UserModellingContext();

        // GET: EventOrganisers
        public ActionResult Index()
        {
            var eventOrganisers = db.EventOrganisers.Include(e => e.Events).Include(e => e.Organisers);
            return View(eventOrganisers.ToList());
        }

        // GET: EventOrganisers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrganisers eventOrganisers = db.EventOrganisers.Find(id);
            if (eventOrganisers == null)
            {
                return HttpNotFound();
            }
            return View(eventOrganisers);
        }

        // GET: EventOrganisers/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "FirstName");
            return View();
        }

        // POST: EventOrganisers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventOrganiserId,EventId,OrganiserId,AssigningDateTime")] EventOrganisers eventOrganisers)
        {
            if (ModelState.IsValid)
            {
                eventOrganisers.AssigningDateTime = DateTime.Now;
                db.EventOrganisers.Add(eventOrganisers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventOrganisers.EventId);
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "FirstName", eventOrganisers.OrganiserId);
            return View(eventOrganisers);
        }

        // GET: EventOrganisers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrganisers eventOrganisers = db.EventOrganisers.Find(id);
            if (eventOrganisers == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventOrganisers.EventId);
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "FirstName", eventOrganisers.OrganiserId);
            return View(eventOrganisers);
        }

        // POST: EventOrganisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventOrganiserId,EventId,OrganiserId,AssigningDateTime")] EventOrganisers eventOrganisers)
        {
            if (ModelState.IsValid)
            {
                eventOrganisers.AssigningDateTime = DateTime.Now;
                db.Entry(eventOrganisers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventOrganisers.EventId);
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "FirstName", eventOrganisers.OrganiserId);
            return View(eventOrganisers);
        }

        // GET: EventOrganisers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrganisers eventOrganisers = db.EventOrganisers.Find(id);
            if (eventOrganisers == null)
            {
                return HttpNotFound();
            }
            return View(eventOrganisers);
        }

        // POST: EventOrganisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventOrganisers eventOrganisers = db.EventOrganisers.Find(id);
            db.EventOrganisers.Remove(eventOrganisers);
            db.SaveChanges();
            return RedirectToAction("Index");
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
