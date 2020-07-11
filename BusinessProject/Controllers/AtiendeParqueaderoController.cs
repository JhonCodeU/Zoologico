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
    public class AtiendeParqueaderoController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: AtiendeParqueadero
        public ActionResult Index()
        {
            return View(db.AtiendeParqueaderoes.ToList());
        }

        // GET: AtiendeParqueadero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtiendeParqueadero atiendeParqueadero = db.AtiendeParqueaderoes.Find(id);
            if (atiendeParqueadero == null)
            {
                return HttpNotFound();
            }
            return View(atiendeParqueadero);
        }

        // GET: AtiendeParqueadero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtiendeParqueadero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoParqueo,fechaParqueo,horaInicio,horaFin,Lugar")] AtiendeParqueadero atiendeParqueadero)
        {
            if (ModelState.IsValid)
            {
                db.AtiendeParqueaderoes.Add(atiendeParqueadero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atiendeParqueadero);
        }

        // GET: AtiendeParqueadero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtiendeParqueadero atiendeParqueadero = db.AtiendeParqueaderoes.Find(id);
            if (atiendeParqueadero == null)
            {
                return HttpNotFound();
            }
            return View(atiendeParqueadero);
        }

        // POST: AtiendeParqueadero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoParqueo,fechaParqueo,horaInicio,horaFin,Lugar")] AtiendeParqueadero atiendeParqueadero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atiendeParqueadero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atiendeParqueadero);
        }

        // GET: AtiendeParqueadero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtiendeParqueadero atiendeParqueadero = db.AtiendeParqueaderoes.Find(id);
            if (atiendeParqueadero == null)
            {
                return HttpNotFound();
            }
            return View(atiendeParqueadero);
        }

        // POST: AtiendeParqueadero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtiendeParqueadero atiendeParqueadero = db.AtiendeParqueaderoes.Find(id);
            db.AtiendeParqueaderoes.Remove(atiendeParqueadero);
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
