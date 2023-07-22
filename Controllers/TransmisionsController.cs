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
    public class TransmisionsController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Transmisions
        public ActionResult Index()
        {
            var transmision = db.Transmision.Include(t => t.Vehiculo);
            return View(transmision.ToList());
        }

        // GET: Transmisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmision.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // GET: Transmisions/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Transmisions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransmisionID,VehiculoID,Tipo,Caja,Traccion")] Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Transmision.Add(transmision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", transmision.VehiculoID);
            return View(transmision);
        }

        // GET: Transmisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmision.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", transmision.VehiculoID);
            return View(transmision);
        }

        // POST: Transmisions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransmisionID,VehiculoID,Tipo,Caja,Traccion")] Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", transmision.VehiculoID);
            return View(transmision);
        }

        // GET: Transmisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmision.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // POST: Transmisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transmision transmision = db.Transmision.Find(id);
            db.Transmision.Remove(transmision);
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
