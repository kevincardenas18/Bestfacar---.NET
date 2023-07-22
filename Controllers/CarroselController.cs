using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaBestfacar.Models;
using System.IO;
using PruebaBestfacar.Permisos;

namespace PruebaBestfacar.Controllers
{
    [Authorize] //SOLO USUARIOS ADMINISTRADORES
    [PermisosRolAttribute(Models.Rol.Administrador)]
    public class CarroselController : Controller
    {
        private PruebaBFC db = new PruebaBFC();


        // GET: Carrosel
        public ActionResult Index()
        {
            return View(db.Carrosel.ToList());
        }

        // GET: Carrosel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrosel carrosel = db.Carrosel.Find(id);
            if (carrosel == null)
            {
                return HttpNotFound();
            }
            return View(carrosel);
        }

        // GET: Carrosel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrosel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carroselID,ImagePath,Nombre,Url")] Carrosel carrosel,HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);
                if((img.Width==2500)||(img.Height==1800))
                {
                    ModelState.AddModelError("", "Resolucion incorrecta utilizar una distinta a 2000 x 1356 px");
                    return View();
                }
                //Upload your pic
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), pic);
                ImagePath.SaveAs(path);
                if (ModelState.IsValid)
                {
                 Carrosel admins = new Carrosel { ImagePath = "~/Content/images/" + pic };
                 db.Carrosel.Add(carrosel);
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                
            }
           return View(carrosel);
        }

        // GET: Carrosel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrosel carrosel = db.Carrosel.Find(id);
            if (carrosel == null)
            {
                return HttpNotFound();
            }
            return View(carrosel);
        }

        // POST: Carrosel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carroselID,ImagePath,Nombre,Url")] Carrosel carrosel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrosel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrosel);
        }

        // GET: Carrosel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrosel carrosel = db.Carrosel.Find(id);
            if (carrosel == null)
            {
                return HttpNotFound();
            }
            return View(carrosel);
        }

        // POST: Carrosel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrosel carrosel = db.Carrosel.Find(id);
            db.Carrosel.Remove(carrosel);
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
