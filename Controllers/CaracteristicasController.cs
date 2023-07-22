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
using System.IO;


namespace PruebaBestfacar.Controllers
{
    [Authorize] //SOLO USUARIOS ADMINISTRADORES
    [PermisosRolAttribute(Models.Rol.Administrador)]
    public class CaracteristicasController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Caracteristicas
        public ActionResult Index()
        {
            var caracteristicas = db.Caracteristicas.Include(c => c.Vehiculo);
            return View(caracteristicas.ToList());
        }

        // GET: Caracteristicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // GET: Caracteristicas/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Modelo");
            return View();
        }

        // POST: Caracteristicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "caracteristicasID,VehiculoID,descripcion,direccion")] Caracteristicas caracteristicas)
        {
            if (ModelState.IsValid)
            {
                db.Caracteristicas.Add(caracteristicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Modelo", caracteristicas.VehiculoID);
            return View(caracteristicas);
        }

        // GET: Caracteristicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Modelo", caracteristicas.VehiculoID);
            return View(caracteristicas);
        }

        // POST: Caracteristicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "caracteristicasID,VehiculoID,descripcion,direccion")] Caracteristicas caracteristicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caracteristicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", caracteristicas.VehiculoID);
            return View(caracteristicas);
        }

        // GET: Caracteristicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // POST: Caracteristicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            db.Caracteristicas.Remove(caracteristicas);
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
