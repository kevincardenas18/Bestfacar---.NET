using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaBestfacar.Models;

namespace PruebaBestfacar.Controllers
{
    public class CalificacionApiController : ApiController
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: api/CalificacionApi
        public IQueryable<Calificacion> GetCalificacion()
        {
            return db.Calificacion;
        }

        // GET: api/CalificacionApi/5
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult GetCalificacion(int id)
        {
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return Ok(calificacion);
        }

        // PUT: api/CalificacionApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalificacion(int id, Calificacion calificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificacion.calificacionID)
            {
                return BadRequest();
            }

            db.Entry(calificacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CalificacionApi
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult PostCalificacion(Calificacion calificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calificacion.Add(calificacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calificacion.calificacionID }, calificacion);
        }

        // DELETE: api/CalificacionApi/5
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult DeleteCalificacion(int id)
        {
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            db.Calificacion.Remove(calificacion);
            db.SaveChanges();

            return Ok(calificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalificacionExists(int id)
        {
            return db.Calificacion.Count(e => e.calificacionID == id) > 0;
        }
    }
}