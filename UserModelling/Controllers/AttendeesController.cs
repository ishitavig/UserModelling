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
    public class AttendeesController : Controller
    {
        private UserModellingContext db = new UserModellingContext();

        // GET: Attendees
        public ActionResult Index()
        {
            return View(db.Attendees.ToList());
        }

        // GET: Attendees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = db.Attendees.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            return View(attendees);
        }

        // GET: Attendees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendeeId,SignUpDateTime,FirstName,LastName,Email,ContactNumber")] Attendees attendees)
        {
            if (ModelState.IsValid)
            {
                attendees.SignUpDateTime = DateTime.Now;
                db.Attendees.Add(attendees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendees);
        }

        // GET: Attendees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = db.Attendees.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            return View(attendees);
        }

        // POST: Attendees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendeeId,SignUpDateTime,FirstName,LastName,Email,ContactNumber")] Attendees attendees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendees);
        }

        // GET: Attendees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = db.Attendees.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            return View(attendees);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendees attendees = db.Attendees.Find(id);
            db.Attendees.Remove(attendees);
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
