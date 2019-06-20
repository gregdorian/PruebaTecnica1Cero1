using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVCPrueba.Models;
using WebMVCPrueba.ViewModel;

namespace WebMVCPrueba.Controllers
{
    public class MunicipioTramitesController : Controller
    {
        private MunicipiosDB db = new MunicipiosDB();

        // GET: MunicipioTramites
        public ActionResult Index()
        {
            var municipioTramite = db.MunicipioTramite.Include(m => m.Municipio).Include(m => m.Tramite);
            
            return View(municipioTramite.ToList());
        }

        // GET: MunicipioTramites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MunicipioTramite municipioTramite = db.MunicipioTramite.Find(id);

            var municipioTramite = db.MunicipioTramite.Include(m => m.Municipio).Include(m => m.Tramite).FirstOrDefault(c => c.Id == id);

            if (municipioTramite == null)
            {
                return HttpNotFound();
            }
            return View(municipioTramite);
        }

        // GET: MunicipioTramites/Create
        public ActionResult Create()
        {
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "CodigoMunicipio");
            ViewBag.TramiteId = new SelectList(db.Tramites, "Id", "CodigoTramite");
     
            var MunicipiosSel = db.Municipios.Select(x => new SelectListItem { Text = x.NombreMunicipio, Value = x.Id.ToString() }).ToList();
            var TramitesSel = db.Tramites.Select(x => new SelectListItem { Text = x.NombreTramite, Value = x.Id.ToString() }).ToList();
            ViewBag.Mpios = MunicipiosSel;
            ViewBag.Tram = TramitesSel;
            return View();
        }

        // POST: MunicipioTramites/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MunicipioId,TramiteId")] MunicipioTramite municipioTramite)
        {
            if (ModelState.IsValid)
            {
                db.MunicipioTramite.Add(municipioTramite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "CodigoMunicipio", municipioTramite.MunicipioId);
            ViewBag.TramiteId = new SelectList(db.Tramites, "Id", "CodigoTramite", municipioTramite.TramiteId);
            return View(municipioTramite);
        }

        // GET: MunicipioTramites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var municipioTramite = db.MunicipioTramite.Include(m => m.Municipio).Include(m => m.Tramite).FirstOrDefault(c => c.Id == id);
            if (municipioTramite == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "NombreMunicipio", municipioTramite.MunicipioId);
            ViewBag.TramiteId = new SelectList(db.Tramites, "Id", "NombreTramite", municipioTramite.TramiteId);


            return View(municipioTramite);
        }

        // POST: MunicipioTramites/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MunicipioId,TramiteId")] MunicipioTramite municipioTramite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipioTramite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "Id", "CodigoMunicipio", municipioTramite.MunicipioId);
            ViewBag.TramiteId = new SelectList(db.Tramites, "Id", "CodigoTramite", municipioTramite.TramiteId);
            return View(municipioTramite);
        }

        // GET: MunicipioTramites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipioTramite municipioTramite = db.MunicipioTramite.Find(id);
            if (municipioTramite == null)
            {
                return HttpNotFound();
            }
            return View(municipioTramite);
        }

        // POST: MunicipioTramites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MunicipioTramite municipioTramite = db.MunicipioTramite.Find(id);
            db.MunicipioTramite.Remove(municipioTramite);
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
