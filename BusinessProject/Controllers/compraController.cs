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
    public class compraController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: compra
        public ActionResult Index()
        {
            var compras = db.compras.Include(c => c.cliente).Include(c => c.planTuristico);
            return View(compras.ToList());
        }

        // GET: compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: compra/Create
        public ActionResult Create()
        {
            ViewBag.fk_idCliente = new SelectList(db.clientes, "idCliente", "nombres");
            ViewBag.fk_idPlan = new SelectList(db.planTuristicoes, "codigoPlan", "nombrePlan");
            return View();
        }

        // POST: compra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoCompra,numeroZonas,precioTotal,cantidadPersonas,fk_idCliente,fk_idPlan")] compra compra)
        {
            compra.precioTotal = 0;

            if (ModelState.IsValid)
            {
                db.compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_idCliente = new SelectList(db.clientes, "idCliente", "nombres", compra.fk_idCliente);
            ViewBag.fk_idPlan = new SelectList(db.planTuristicoes, "codigoPlan", "nombrePlan", compra.fk_idPlan);
            return View(compra);
        }

        // GET: compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_idCliente = new SelectList(db.clientes, "idCliente", "nombres", compra.fk_idCliente);
            ViewBag.fk_idPlan = new SelectList(db.planTuristicoes, "codigoPlan", "nombrePlan", compra.fk_idPlan);
            return View(compra);
        }

        // POST: compra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoCompra,numeroZonas,precioTotal,cantidadPersonas,fk_idCliente,fk_idPlan")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_idCliente = new SelectList(db.clientes, "idCliente", "nombres", compra.fk_idCliente);
            ViewBag.fk_idPlan = new SelectList(db.planTuristicoes, "codigoPlan", "nombrePlan", compra.fk_idPlan);
            return View(compra);
        }

        // GET: compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compra compra = db.compras.Find(id);
            db.compras.Remove(compra);
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
