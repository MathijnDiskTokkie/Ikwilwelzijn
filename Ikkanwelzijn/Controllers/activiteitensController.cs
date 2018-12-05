using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ikkanwelzijn.Models;

namespace Ikkanwelzijn.Controllers
{
    public class activiteitensController : Controller
    {
        private ikwzEntities1 db = new ikwzEntities1();

        // GET: activiteitens
        public ActionResult Index()
        {
            var activiteiten = db.activiteiten.Include(a => a.clienten).Include(a => a.organisatie);
            return View(activiteiten.ToList());
        }

        // GET: activiteitens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activiteiten activiteiten = db.activiteiten.Find(id);
            if (activiteiten == null)
            {
                return HttpNotFound();
            }
            return View(activiteiten);
        }

        // GET: activiteitens/Create
        public ActionResult Create()
        {
            ViewBag.clienten_clientid = new SelectList(db.clienten, "clientid", "clientvoornaam");
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam");
            return View();
        }

        // POST: activiteitens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activiteitid,activiteitnaam,activiteitdatum,activiteitplaats,clienten_clientid,organisatie_organisatieid")] activiteiten activiteiten)
        {
            if (ModelState.IsValid)
            {
                db.activiteiten.Add(activiteiten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienten_clientid = new SelectList(db.clienten, "clientid", "clientvoornaam", activiteiten.clienten_clientid);
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", activiteiten.organisatie_organisatieid);
            return View(activiteiten);
        }

        // GET: activiteitens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activiteiten activiteiten = db.activiteiten.Find(id);
            if (activiteiten == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienten_clientid = new SelectList(db.clienten, "clientid", "clientvoornaam", activiteiten.clienten_clientid);
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", activiteiten.organisatie_organisatieid);
            return View(activiteiten);
        }

        // POST: activiteitens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "activiteitid,activiteitnaam,activiteitdatum,activiteitplaats,clienten_clientid,organisatie_organisatieid")] activiteiten activiteiten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activiteiten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienten_clientid = new SelectList(db.clienten, "clientid", "clientvoornaam", activiteiten.clienten_clientid);
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", activiteiten.organisatie_organisatieid);
            return View(activiteiten);
        }

        // GET: activiteitens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activiteiten activiteiten = db.activiteiten.Find(id);
            if (activiteiten == null)
            {
                return HttpNotFound();
            }
            return View(activiteiten);
        }

        // POST: activiteitens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            activiteiten activiteiten = db.activiteiten.Find(id);
            db.activiteiten.Remove(activiteiten);
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
