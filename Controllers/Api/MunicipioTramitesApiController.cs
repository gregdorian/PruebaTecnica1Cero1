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
    public class MunicipioTramitesApiController : ApiController
    {
        private MunicipiosDB db = new MunicipiosDB();

        // GET: api/MunicipioTramites
        public IQueryable<MunicipioTramite> GetMunicipioTramite()
        {
            return db.MunicipioTramite;
        }

        // GET: api/MunicipioTramites/5
        [ResponseType(typeof(MunicipioTramite))]
        public IHttpActionResult GetMunicipioTramite(int id)
        {
            MunicipioTramite municipioTramite = db.MunicipioTramite.Find(id);
            if (municipioTramite == null)
            {
                return NotFound();
            }

            return Ok(municipioTramite);
        }

        // PUT: api/MunicipioTramites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMunicipioTramite(int id, MunicipioTramite municipioTramite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != municipioTramite.Id)
            {
                return BadRequest();
            }

            db.Entry(municipioTramite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioTramiteExists(id))
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

        // POST: api/MunicipioTramites
        [ResponseType(typeof(MunicipioTramite))]
        public IHttpActionResult PostMunicipioTramite(MunicipioTramite municipioTramite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MunicipioTramite.Add(municipioTramite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = municipioTramite.Id }, municipioTramite);
        }

        // DELETE: api/MunicipioTramites/5
        [ResponseType(typeof(MunicipioTramite))]
        public IHttpActionResult DeleteMunicipioTramite(int id)
        {
            MunicipioTramite municipioTramite = db.MunicipioTramite.Find(id);
            if (municipioTramite == null)
            {
                return NotFound();
            }

            db.MunicipioTramite.Remove(municipioTramite);
            db.SaveChanges();

            return Ok(municipioTramite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MunicipioTramiteExists(int id)
        {
            return db.MunicipioTramite.Count(e => e.Id == id) > 0;
        }
    }
}