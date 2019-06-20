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
using WebMVCPrueba.Models;

namespace WebMVCPrueba.Controllers.Api
{
    public class TramitesApiController : ApiController
    {
        private MunicipiosDB db = new MunicipiosDB();

        // GET: api/Tramites
        public IQueryable<Tramite> GetTramites()
        {
            return db.Tramites;
        }

        // GET: api/Tramites/5
        [ResponseType(typeof(Tramite))]
        public IHttpActionResult GetTramite(int id)
        {
            Tramite tramite = db.Tramites.Find(id);
            if (tramite == null)
            {
                return NotFound();
            }

            return Ok(tramite);
        }

        // PUT: api/Tramites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTramite(int id, Tramite tramite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tramite.Id)
            {
                return BadRequest();
            }

            db.Entry(tramite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteExists(id))
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

        // POST: api/Tramites
        [ResponseType(typeof(Tramite))]
        public IHttpActionResult PostTramite(Tramite tramite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tramites.Add(tramite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tramite.Id }, tramite);
        }

        // DELETE: api/Tramites/5
        [ResponseType(typeof(Tramite))]
        public IHttpActionResult DeleteTramite(int id)
        {
            Tramite tramite = db.Tramites.Find(id);
            if (tramite == null)
            {
                return NotFound();
            }

            db.Tramites.Remove(tramite);
            db.SaveChanges();

            return Ok(tramite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TramiteExists(int id)
        {
            return db.Tramites.Count(e => e.Id == id) > 0;
        }
    }
}