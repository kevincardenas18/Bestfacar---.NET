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
    public class RolusuariosController : ApiController
    {
        private PruebaBFC db = new PruebaBFC();

        // GET: api/Rolusuarios
        public IQueryable<RolUsuario> GetRolUsuarios()
        {
            return db.RolUsuarios;
        }

        // GET: api/Rolusuarios/5
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult GetRolUsuario(int id)
        {
            RolUsuario rolUsuario = db.RolUsuarios.Find(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            return Ok(rolUsuario);
        }

        // PUT: api/Rolusuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRolUsuario(int id, RolUsuario rolUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolUsuario.RolID)
            {
                return BadRequest();
            }

            db.Entry(rolUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolUsuarioExists(id))
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

        // POST: api/Rolusuarios
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult PostRolUsuario(RolUsuario rolUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RolUsuarios.Add(rolUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rolUsuario.RolID }, rolUsuario);
        }

        // DELETE: api/Rolusuarios/5
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult DeleteRolUsuario(int id)
        {
            RolUsuario rolUsuario = db.RolUsuarios.Find(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            db.RolUsuarios.Remove(rolUsuario);
            db.SaveChanges();

            return Ok(rolUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolUsuarioExists(int id)
        {
            return db.RolUsuarios.Count(e => e.RolID == id) > 0;
        }
    }
}