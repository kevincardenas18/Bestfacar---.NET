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
    public class CaracteristicasApiController : ApiController
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: api/CaracteristicasApi
        public IQueryable<Caracteristicas> GetCaracteristicas()
        {
            return db.Caracteristicas;
        }

        // GET: api/CaracteristicasApi/5
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult GetCaracteristicas(int id)
        {
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return NotFound();
            }

            return Ok(caracteristicas);
        }

        // PUT: api/CaracteristicasApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaracteristicas(int id, Caracteristicas caracteristicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caracteristicas.caracteristicasID)
            {
                return BadRequest();
            }

            db.Entry(caracteristicas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristicasExists(id))
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

        // POST: api/CaracteristicasApi
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult PostCaracteristicas(Caracteristicas caracteristicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Caracteristicas.Add(caracteristicas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caracteristicas.caracteristicasID }, caracteristicas);
        }

        // DELETE: api/CaracteristicasApi/5
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult DeleteCaracteristicas(int id)
        {
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return NotFound();
            }

            db.Caracteristicas.Remove(caracteristicas);
            db.SaveChanges();

            return Ok(caracteristicas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaracteristicasExists(int id)
        {
            return db.Caracteristicas.Count(e => e.caracteristicasID == id) > 0;
        }
    }
}