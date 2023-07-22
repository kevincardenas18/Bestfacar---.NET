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
    public class CarroselApiController : ApiController
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: api/CarroselApi
        public IQueryable<Carrosel> GetCarrosel()
        {
            return db.Carrosel;
        }

        // GET: api/CarroselApi/5
        [ResponseType(typeof(Carrosel))]
        public IHttpActionResult GetCarrosel(int id)
        {
            Carrosel carrosel = db.Carrosel.Find(id);
            if (carrosel == null)
            {
                return NotFound();
            }

            return Ok(carrosel);
        }

        // PUT: api/CarroselApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarrosel(int id, Carrosel carrosel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carrosel.carroselID)
            {
                return BadRequest();
            }

            db.Entry(carrosel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroselExists(id))
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

        // POST: api/CarroselApi
        [ResponseType(typeof(Carrosel))]
        public IHttpActionResult PostCarrosel(Carrosel carrosel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carrosel.Add(carrosel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carrosel.carroselID }, carrosel);
        }

        // DELETE: api/CarroselApi/5
        [ResponseType(typeof(Carrosel))]
        public IHttpActionResult DeleteCarrosel(int id)
        {
            Carrosel carrosel = db.Carrosel.Find(id);
            if (carrosel == null)
            {
                return NotFound();
            }

            db.Carrosel.Remove(carrosel);
            db.SaveChanges();

            return Ok(carrosel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarroselExists(int id)
        {
            return db.Carrosel.Count(e => e.carroselID == id) > 0;
        }
    }
}