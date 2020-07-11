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
    public class trabajadorController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: trabajador
        public ActionResult Index()
        {
            var trabajadors = db.trabajadors.Include(t => t.ZonaGeografica);
            return View(trabajadors.ToList());
        }

        // GET: trabajador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajadors.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: trabajador/Create
        public ActionResult Create()
        {
            ViewBag.fk_codigoZona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona");
            return View();
        }

        // POST: trabajador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido,edad,celular,fk_codigoZona")] trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.trabajadors.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_codigoZona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", trabajador.fk_codigoZona);
            return View(trabajador);
        }

        // GET: trabajador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajadors.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_codigoZona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", trabajador.fk_codigoZona);
            return View(trabajador);
        }

        // POST: trabajador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,edad,celular,fk_codigoZona")] trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_codigoZona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", trabajador.fk_codigoZona);
            return View(trabajador);
        }

        // GET: trabajador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajador trabajador = db.trabajadors.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trabajador trabajador = db.trabajadors.Find(id);
            db.trabajadors.Remove(trabajador);
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
