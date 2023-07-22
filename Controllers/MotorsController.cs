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
    public class MotorsController : Controller
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: Motors
        public ActionResult Index()
        {
            var motor = db.Motor.Include(m => m.Vehiculo);
            return View(motor.ToList());
        }

        // GET: Motors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.Motor.Find(id);
            if (motor == null)
            {
                return HttpNotFound();
            }
            return View(motor);
        }

        // GET: Motors/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca");
            return View();
        }

        // POST: Motors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotorID,VehiculoID,Cilindraje,Potencia,Torque,Combustible")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                db.Motor.Add(motor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", motor.VehiculoID);
            return View(motor);
        }

        // GET: Motors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.Motor.Find(id);
            if (motor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", motor.VehiculoID);
            return View(motor);
        }

        // POST: Motors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotorID,VehiculoID,Cilindraje,Potencia,Torque,Combustible")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehiculoID = new SelectList(db.Vehiculo, "VehiculoID", "Marca", motor.VehiculoID);
            return View(motor);
        }

        // GET: Motors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.Motor.Find(id);
            if (motor == null)
            {
                return HttpNotFound();
            }
            return View(motor);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motor motor = db.Motor.Find(id);
            db.Motor.Remove(motor);
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
