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
    public class MunicipiosApiController : ApiController
    {
        private MunicipiosDB db = new MunicipiosDB();

        // GET: api/MunicipiosApi
        public IQueryable<Municipio> GetMunicipios()
        {
            return db.Municipios;
        }

        // GET: api/MunicipiosApi/5
        [ResponseType(typeof(Municipio))]
        public IHttpActionResult GetMunicipio(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return NotFound();
            }

            return Ok(municipio);
        }

        // PUT: api/MunicipiosApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMunicipio(int id, Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != municipio.Id)
            {
                return BadRequest();
            }

            db.Entry(municipio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioExists(id))
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

        // POST: api/MunicipiosApi
        [ResponseType(typeof(Municipio))]
        public IHttpActionResult PostMunicipio(Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Municipios.Add(municipio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = municipio.Id }, municipio);
        }

        // DELETE: api/MunicipiosApi/5
        [ResponseType(typeof(Municipio))]
        public IHttpActionResult DeleteMunicipio(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return NotFound();
            }

            db.Municipios.Remove(municipio);
            db.SaveChanges();

            return Ok(municipio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MunicipioExists(int id)
        {
            return db.Municipios.Count(e => e.Id == id) > 0;
        }
    }
}