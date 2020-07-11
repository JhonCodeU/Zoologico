using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessProject.Models;
using BusinessProject.Filters;

namespace BusinessProject.Controllers
{
    public class citaController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: cita
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Index()
        {
            var citas = db.citas.Include(c => c.Animal).Include(c => c.veterinario);
            return View(citas.ToList());
        }

        // GET: cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: cita/Create
        public ActionResult Create()
        {
            ViewBag.fk_codigoAnimal = new SelectList(db.Animals, "codigoAnimal", "nombreAnimal");
            ViewBag.fk_codigoVeterinario = new SelectList(db.veterinarios, "codigoVeterinario", "nombre");
            return View();
        }

        // POST: cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoCita,nombreCita,fechaCita,horaInicio,horaFin,fk_codigoVeterinario,fk_codigoAnimal")] cita cita)
        {
            cita.fechaCita = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_codigoAnimal = new SelectList(db.Animals, "codigoAnimal", "nombreAnimal", cita.fk_codigoAnimal);
            ViewBag.fk_codigoVeterinario = new SelectList(db.veterinarios, "codigoVeterinario", "nombre", cita.fk_codigoVeterinario);
            return View(cita);
        }

        // GET: cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_codigoAnimal = new SelectList(db.Animals, "codigoAnimal", "nombreAnimal", cita.fk_codigoAnimal);
            ViewBag.fk_codigoVeterinario = new SelectList(db.veterinarios, "codigoVeterinario", "nombre", cita.fk_codigoVeterinario);
            return View(cita);
        }

        // POST: cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoCita,nombreCita,fechaCita,horaInicio,horaFin,fk_codigoVeterinario,fk_codigoAnimal")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_codigoAnimal = new SelectList(db.Animals, "codigoAnimal", "nombreAnimal", cita.fk_codigoAnimal);
            ViewBag.fk_codigoVeterinario = new SelectList(db.veterinarios, "codigoVeterinario", "nombre", cita.fk_codigoVeterinario);
            return View(cita);
        }

        // GET: cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cita cita = db.citas.Find(id);
            db.citas.Remove(cita);
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
