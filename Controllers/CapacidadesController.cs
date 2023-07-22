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
    public class CapacidadesController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Capacidades
        public ActionResult Index()
        {
            var capacidades = db.Capacidades.Include(c => c.Vehiculo);
            return View(capacidades.ToList());
        }

        // GET: Capacidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacidades capacidades = db.Capacidades.Find(id);
            if (capacidades == null)
            {
                return HttpNotFound();
            }
            return View(capacidades);
        }

        // GET: Capacidades/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Capacidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CapacidadesID,VehiculoID,NumeroPuertas,NumeroPasajeros,Longitud,Ancho,Alto,DistanciaEjes,AlturaSuelo,VolumenMaletero")] Capacidades capacidades)
        {
            if (ModelState.IsValid)
            {
                db.Capacidades.Add(capacidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", capacidades.VehiculoID);
            return View(capacidades);
        }

        // GET: Capacidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacidades capacidades = db.Capacidades.Find(id);
            if (capacidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", capacidades.VehiculoID);
            return View(capacidades);
        }

        // POST: Capacidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CapacidadesID,VehiculoID,NumeroPuertas,NumeroPasajeros,Longitud,Ancho,Alto,DistanciaEjes,AlturaSuelo,VolumenMaletero")] Capacidades capacidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", capacidades.VehiculoID);
            return View(capacidades);
        }

        // GET: Capacidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacidades capacidades = db.Capacidades.Find(id);
            if (capacidades == null)
            {
                return HttpNotFound();
            }
            return View(capacidades);
        }

        // POST: Capacidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Capacidades capacidades = db.Capacidades.Find(id);
            db.Capacidades.Remove(capacidades);
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
