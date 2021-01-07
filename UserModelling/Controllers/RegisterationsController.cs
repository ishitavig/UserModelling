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
    public class RegisterationsController : Controller
    {
        private UserModellingContext db = new UserModellingContext();

        // GET: Registerations
        public ActionResult Index()
        {
            var registerations = db.Registerations.Include(r => r.Attendees).Include(r => r.Events);
            return View(registerations.ToList());
        }

        // GET: Registerations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerations registerations = db.Registerations.Find(id);
            if (registerations == null)
            {
                return HttpNotFound();
            }
            return View(registerations);
        }

        // GET: Registerations/Create
        public ActionResult Create()
        {
            ViewBag.AttendeeId = new SelectList(db.Attendees, "AttendeeId", "FirstName");
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        }

        // POST: Registerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterationId,EventId,AttendeeId,RegisterationDateTime")] Registerations registerations)
        {
            if (ModelState.IsValid)
            {
                registerations.RegisterationDateTime = DateTime.Now;
                db.Registerations.Add(registerations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendeeId = new SelectList(db.Attendees, "AttendeeId", "FirstName", registerations.AttendeeId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", registerations.EventId);
            return View(registerations);
        }

        // GET: Registerations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerations registerations = db.Registerations.Find(id);
            if (registerations == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendeeId = new SelectList(db.Attendees, "AttendeeId", "FirstName", registerations.AttendeeId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", registerations.EventId);
            return View(registerations);
        }

        // POST: Registerations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterationId,EventId,AttendeeId,RegisterationDateTime")] Registerations registerations)
        {
            if (ModelState.IsValid)
            {
                registerations.RegisterationDateTime = DateTime.Now;
                db.Entry(registerations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendeeId = new SelectList(db.Attendees, "AttendeeId", "FirstName", registerations.AttendeeId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", registerations.EventId);
            return View(registerations);
        }

        // GET: Registerations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerations registerations = db.Registerations.Find(id);
            if (registerations == null)
            {
                return HttpNotFound();
            }
            return View(registerations);
        }

        // POST: Registerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registerations registerations = db.Registerations.Find(id);
            db.Registerations.Remove(registerations);
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
