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
    public class ZonaGeograficaController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: ZonaGeografica
        public ActionResult Index()
        {
            var zonaGeograficas = db.ZonaGeograficas.Include(z => z.Zoologico);
            return View(zonaGeograficas.ToList());
        }

        // GET: ZonaGeografica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeograficas.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            return View(zonaGeografica);
        }

        // GET: ZonaGeografica/Create
        public ActionResult Create()
        {
            ViewBag.codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo");
            return View();
        }

        // POST: ZonaGeografica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoZona,nombreZona,codigoZoo")] ZonaGeografica zonaGeografica)
        {
            if (ModelState.IsValid)
            {
                db.ZonaGeograficas.Add(zonaGeografica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", zonaGeografica.codigoZoo);
            return View(zonaGeografica);
        }

        // GET: ZonaGeografica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeograficas.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", zonaGeografica.codigoZoo);
            return View(zonaGeografica);
        }

        // POST: ZonaGeografica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoZona,nombreZona,codigoZoo")] ZonaGeografica zonaGeografica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zonaGeografica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoZoo = new SelectList(db.Zoologicoes, "codigoZoo", "nombreZoo", zonaGeografica.codigoZoo);
            return View(zonaGeografica);
        }

        // GET: ZonaGeografica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeograficas.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            return View(zonaGeografica);
        }

        // POST: ZonaGeografica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZonaGeografica zonaGeografica = db.ZonaGeograficas.Find(id);
            db.ZonaGeograficas.Remove(zonaGeografica);
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
