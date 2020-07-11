using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessProject.Models;

namespace BusinessProject.Controllers
{
    public class TipoAnimalController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: TipoAnimal
        public ActionResult Index()
        {
            return View(db.TipoAnimals.ToList());
        }

        // GET: TipoAnimal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimals.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAnimal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoTipoAnimal,nombreTipo")] TipoAnimal tipoAnimal)
        {
            if (ModelState.IsValid)
            {
                db.TipoAnimals.Add(tipoAnimal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimals.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // POST: TipoAnimal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoTipoAnimal,nombreTipo")] TipoAnimal tipoAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAnimal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimals.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // POST: TipoAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAnimal tipoAnimal = db.TipoAnimals.Find(id);
            db.TipoAnimals.Remove(tipoAnimal);
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
