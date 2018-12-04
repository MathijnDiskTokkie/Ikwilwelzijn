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
    public class clientensController : Controller
    {
        private ikwzEntities1 db = new ikwzEntities1();

        // GET: clientens
        public ActionResult Index()
        {
            var clienten = db.clienten.Include(c => c.organisatie);
            return View(clienten.ToList());
        }

        // GET: clientens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clienten clienten = db.clienten.Find(id);
            if (clienten == null)
            {
                return HttpNotFound();
            }
            return View(clienten);
        }

        // GET: clientens/Create
        public ActionResult Create()
        {
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam");
            return View();
        }

        // POST: clientens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientid,clientnaam,clientachternaam,clienttussenvoegsel,clientwoonplaats,clientadres,clientgeslacht,organisatie_organisatieid,voorkeur1,voorkeur2,voorkeur3")] clienten clienten)
        {
            if (ModelState.IsValid)
            {
                db.clienten.Add(clienten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", clienten.organisatie_organisatieid);
            return View(clienten);
        }

        // GET: clientens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clienten clienten = db.clienten.Find(id);
            if (clienten == null)
            {
                return HttpNotFound();
            }
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", clienten.organisatie_organisatieid);
            return View(clienten);
        }

        // POST: clientens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientid,clientnaam,clientachternaam,clienttussenvoegsel,clientwoonplaats,clientadres,clientgeslacht,organisatie_organisatieid,voorkeur1,voorkeur2,voorkeur3")] clienten clienten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.organisatie_organisatieid = new SelectList(db.organisatie, "organisatieid", "organisatienaam", clienten.organisatie_organisatieid);
            return View(clienten);
        }

        // GET: clientens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clienten clienten = db.clienten.Find(id);
            if (clienten == null)
            {
                return HttpNotFound();
            }
            return View(clienten);
        }

        // POST: clientens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clienten clienten = db.clienten.Find(id);
            db.clienten.Remove(clienten);
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
