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
    public class OrganisersController : Controller
    {
        private UserModellingContext db = new UserModellingContext();

        // GET: Organisers
        public ActionResult Index()
        {
            return View(db.Organisers.ToList());
        }

        // GET: Organisers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisers organisers = db.Organisers.Find(id);
            if (organisers == null)
            {
                return HttpNotFound();
            }
            return View(organisers);
        }

        // GET: Organisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organisers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganiserId,HireDateTime,FirstName,LastName,Email,ContactNumber")] Organisers organisers)
        {
            if (ModelState.IsValid)
            {
                db.Organisers.Add(organisers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organisers);
        }

        // GET: Organisers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisers organisers = db.Organisers.Find(id);
            if (organisers == null)
            {
                return HttpNotFound();
            }
            return View(organisers);
        }

        // POST: Organisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganiserId,HireDateTime,FirstName,LastName,Email,ContactNumber")] Organisers organisers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organisers);
        }

        // GET: Organisers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisers organisers = db.Organisers.Find(id);
            if (organisers == null)
            {
                return HttpNotFound();
            }
            return View(organisers);
        }

        // POST: Organisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisers organisers = db.Organisers.Find(id);
            db.Organisers.Remove(organisers);
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
