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
    public class AnimalController : Controller
    {
        private ZooEntities1 db = new ZooEntities1();

        // GET: Animal
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.TipoAnimal).Include(a => a.ZonaGeografica);
            return View(animals.ToList());
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.fk_codigo_tipoAnimal = new SelectList(db.TipoAnimals, "codigoTipoAnimal", "nombreTipo");
            ViewBag.fk_codigo_zona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoAnimal,nombreAnimal,fk_codigo_tipoAnimal,fk_codigo_zona,ImgAnimal")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_codigo_tipoAnimal = new SelectList(db.TipoAnimals, "codigoTipoAnimal", "nombreTipo", animal.fk_codigo_tipoAnimal);
            ViewBag.fk_codigo_zona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", animal.fk_codigo_zona);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_codigo_tipoAnimal = new SelectList(db.TipoAnimals, "codigoTipoAnimal", "nombreTipo", animal.fk_codigo_tipoAnimal);
            ViewBag.fk_codigo_zona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", animal.fk_codigo_zona);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoAnimal,nombreAnimal,fk_codigo_tipoAnimal,fk_codigo_zona,ImgAnimal")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_codigo_tipoAnimal = new SelectList(db.TipoAnimals, "codigoTipoAnimal", "nombreTipo", animal.fk_codigo_tipoAnimal);
            ViewBag.fk_codigo_zona = new SelectList(db.ZonaGeograficas, "codigoZona", "nombreZona", animal.fk_codigo_zona);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
