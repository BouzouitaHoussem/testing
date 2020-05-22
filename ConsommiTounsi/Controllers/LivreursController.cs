using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsommiTounsi.Models;
using Solution.Domain.Entities;

namespace ConsommiTounsi.Controllers
{
    public class LivreursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Livreurs
        public ActionResult Index()
        {
            return View(db.Livreurs.ToList());
        }

        // GET: Livreurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // GET: Livreurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livreurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Salary,Address,Age")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Livreurs.Add(livreur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livreur);
        }

        // GET: Livreurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: Livreurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Salary,Address,Age")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livreur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livreur);
        }

        // GET: Livreurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreurs.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: Livreurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livreur livreur = db.Livreurs.Find(id);
            db.Livreurs.Remove(livreur);
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
