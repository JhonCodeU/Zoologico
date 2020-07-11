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
    public class vehiculoController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: vehiculo
        public ActionResult Index()
        {
            var vehiculoes = db.vehiculoes.Include(v => v.AtiendeParqueadero);
            return View(vehiculoes.ToList());
        }

        // GET: vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.fk_codigoParqueo = new SelectList(db.AtiendeParqueaderoes, "codigoParqueo", "Lugar");
            return View();
        }

        // POST: vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,marca,color,placa,propietario,fk_codigoParqueo")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.vehiculoes.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_codigoParqueo = new SelectList(db.AtiendeParqueaderoes, "codigoParqueo", "Lugar", vehiculo.fk_codigoParqueo);
            return View(vehiculo);
        }

        // GET: vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_codigoParqueo = new SelectList(db.AtiendeParqueaderoes, "codigoParqueo", "Lugar", vehiculo.fk_codigoParqueo);
            return View(vehiculo);
        }

        // POST: vehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,marca,color,placa,propietario,fk_codigoParqueo")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_codigoParqueo = new SelectList(db.AtiendeParqueaderoes, "codigoParqueo", "Lugar", vehiculo.fk_codigoParqueo);
            return View(vehiculo);
        }

        // GET: vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehiculo vehiculo = db.vehiculoes.Find(id);
            db.vehiculoes.Remove(vehiculo);
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
