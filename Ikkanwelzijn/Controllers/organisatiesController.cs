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
    public class organisatiesController : Controller
    {
        private ikwzEntities1 db = new ikwzEntities1();

        // GET: organisaties
        public ActionResult Index()
        {
            return View(db.organisatie.ToList());
        }

        // GET: organisaties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organisatie organisatie = db.organisatie.Find(id);
            if (organisatie == null)
            {
                return HttpNotFound();
            }
            return View(organisatie);
        }

        // GET: organisaties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: organisaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "organisatieid,organisatienaam,organisatieplaats,clientid,activiteitid")] organisatie organisatie)
        {
            if (ModelState.IsValid)
            {
                db.organisatie.Add(organisatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organisatie);
        }

        // GET: organisaties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organisatie organisatie = db.organisatie.Find(id);
            if (organisatie == null)
            {
                return HttpNotFound();
            }
            return View(organisatie);
        }

        // POST: organisaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "organisatieid,organisatienaam,organisatieplaats,clientid,activiteitid")] organisatie organisatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organisatie);
        }

        // GET: organisaties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organisatie organisatie = db.organisatie.Find(id);
            if (organisatie == null)
            {
                return HttpNotFound();
            }
            return View(organisatie);
        }

        // POST: organisaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            organisatie organisatie = db.organisatie.Find(id);
            db.organisatie.Remove(organisatie);
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
