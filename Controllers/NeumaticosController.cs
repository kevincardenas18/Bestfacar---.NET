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
    public class NeumaticosController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Neumaticos
        public ActionResult Index()
        {
            var neumaticos = db.Neumaticos.Include(n => n.Vehiculo);
            return View(neumaticos.ToList());
        }

        // GET: Neumaticos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neumaticos neumaticos = db.Neumaticos.Find(id);
            if (neumaticos == null)
            {
                return HttpNotFound();
            }
            return View(neumaticos);
        }

        // GET: Neumaticos/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Neumaticos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NeumaticosID,VehiculoID,Descripcion,TipoAros")] Neumaticos neumaticos)
        {
            if (ModelState.IsValid)
            {
                db.Neumaticos.Add(neumaticos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", neumaticos.VehiculoID);
            return View(neumaticos);
        }

        // GET: Neumaticos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neumaticos neumaticos = db.Neumaticos.Find(id);
            if (neumaticos == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", neumaticos.VehiculoID);
            return View(neumaticos);
        }

        // POST: Neumaticos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NeumaticosID,VehiculoID,Descripcion,TipoAros")] Neumaticos neumaticos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neumaticos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", neumaticos.VehiculoID);
            return View(neumaticos);
        }

        // GET: Neumaticos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neumaticos neumaticos = db.Neumaticos.Find(id);
            if (neumaticos == null)
            {
                return HttpNotFound();
            }
            return View(neumaticos);
        }

        // POST: Neumaticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neumaticos neumaticos = db.Neumaticos.Find(id);
            db.Neumaticos.Remove(neumaticos);
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
