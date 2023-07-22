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
    public class SuspensionsController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Suspensions
        public ActionResult Index()
        {
            var suspension = db.Suspension.Include(s => s.Vehiculo);
            return View(suspension.ToList());
        }

        // GET: Suspensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspension.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            return View(suspension);
        }

        // GET: Suspensions/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Suspensions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuspensionID,VehiculoID,Delantera,Trasera")] Suspension suspension)
        {
            if (ModelState.IsValid)
            {
                db.Suspension.Add(suspension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", suspension.VehiculoID);
            return View(suspension);
        }

        // GET: Suspensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspension.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", suspension.VehiculoID);
            return View(suspension);
        }

        // POST: Suspensions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuspensionID,VehiculoID,Delantera,Trasera")] Suspension suspension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", suspension.VehiculoID);
            return View(suspension);
        }

        // GET: Suspensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspension.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            return View(suspension);
        }

        // POST: Suspensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspension suspension = db.Suspension.Find(id);
            db.Suspension.Remove(suspension);
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
