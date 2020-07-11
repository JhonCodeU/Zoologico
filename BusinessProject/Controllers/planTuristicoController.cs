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
    public class planTuristicoController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: planTuristico
        public ActionResult Index()
        {
            var planTuristicoes = db.planTuristicoes.Include(p => p.Zoologico);
            return View(planTuristicoes.ToList());
        }

        // GET: planTuristico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planTuristico planTuristico = db.planTuristicoes.Find(id);
            if (planTuristico == null)
            {
                return HttpNotFound();
            }
            return View(planTuristico);
        }

        // GET: planTuristico/Create
        public ActionResult Create()
        {
            ViewBag.fk_codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo");
            return View();
        }

        // POST: planTuristico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoPlan,nombrePlan,precioPlan,fk_codigoZoo")] planTuristico planTuristico)
        {
            if (ModelState.IsValid)
            {
                db.planTuristicoes.Add(planTuristico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", planTuristico.fk_codigoZoo);
            return View(planTuristico);
        }

        // GET: planTuristico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planTuristico planTuristico = db.planTuristicoes.Find(id);
            if (planTuristico == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", planTuristico.fk_codigoZoo);
            return View(planTuristico);
        }

        // POST: planTuristico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoPlan,nombrePlan,precioPlan,fk_codigoZoo")] planTuristico planTuristico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planTuristico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", planTuristico.fk_codigoZoo);
            return View(planTuristico);
        }

        // GET: planTuristico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planTuristico planTuristico = db.planTuristicoes.Find(id);
            if (planTuristico == null)
            {
                return HttpNotFound();
            }
            return View(planTuristico);
        }

        // POST: planTuristico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planTuristico planTuristico = db.planTuristicoes.Find(id);
            db.planTuristicoes.Remove(planTuristico);
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
