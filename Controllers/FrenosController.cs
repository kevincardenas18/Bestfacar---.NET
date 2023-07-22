using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaBestfacar.Models;
using PruebaBestfacar.Permisos;

namespace PruebaBestfacar.Controllers
{
    [Authorize] //SOLO USUARIOS ADMINISTRADORES
    [PermisosRolAttribute(Models.Rol.Administrador)]
    public class FrenosController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Frenos
        public ActionResult Index()
        {
            var frenos = db.Frenos.Include(f => f.Vehiculo);
            return View(frenos.ToList());
        }

        // GET: Frenos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frenos frenos = db.Frenos.Find(id);
            if (frenos == null)
            {
                return HttpNotFound();
            }
            return View(frenos);
        }

        // GET: Frenos/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Frenos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrenosID,VehiculoID,FrenosDelanteros,FrenosTraseros,FrenosEstacionamiento")] Frenos frenos)
        {
            if (ModelState.IsValid)
            {
                db.Frenos.Add(frenos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", frenos.VehiculoID);
            return View(frenos);
        }

        // GET: Frenos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frenos frenos = db.Frenos.Find(id);
            if (frenos == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", frenos.VehiculoID);
            return View(frenos);
        }

        // POST: Frenos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrenosID,VehiculoID,FrenosDelanteros,FrenosTraseros,FrenosEstacionamiento")] Frenos frenos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frenos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", frenos.VehiculoID);
            return View(frenos);
        }

        // GET: Frenos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frenos frenos = db.Frenos.Find(id);
            if (frenos == null)
            {
                return HttpNotFound();
            }
            return View(frenos);
        }

        // POST: Frenos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frenos frenos = db.Frenos.Find(id);
            db.Frenos.Remove(frenos);
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
