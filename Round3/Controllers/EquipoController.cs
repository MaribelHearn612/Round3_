using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Round3;

namespace Round3.Controllers
{
    public class EquipoController : Controller
    {
        private UNAPEC_PRESTAMOEntitie db = new UNAPEC_PRESTAMOEntitie();

        // GET: Equipo
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Modelo).Include(e => e.TecnologiaConexion).Include(e => e.TipoEquipo);
            return View(equipo.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo");
            ViewBag.idTC = new SelectList(db.TecnologiaConexion, "idTC", "nombreTC");
            ViewBag.idTE = new SelectList(db.TipoEquipo, "idTE", "nombreTE");
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipo,nombreEquipo,descripcionEquipo,serial,idTE,idModelo,idTC,estadoEquipo")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", equipo.idModelo);
            ViewBag.idTC = new SelectList(db.TecnologiaConexion, "idTC", "nombreTC", equipo.idTC);
            ViewBag.idTE = new SelectList(db.TipoEquipo, "idTE", "nombreTE", equipo.idTE);
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", equipo.idModelo);
            ViewBag.idTC = new SelectList(db.TecnologiaConexion, "idTC", "nombreTC", equipo.idTC);
            ViewBag.idTE = new SelectList(db.TipoEquipo, "idTE", "nombreTE", equipo.idTE);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipo,nombreEquipo,descripcionEquipo,serial,idTE,idModelo,idTC,estadoEquipo")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", equipo.idModelo);
            ViewBag.idTC = new SelectList(db.TecnologiaConexion, "idTC", "nombreTC", equipo.idTC);
            ViewBag.idTE = new SelectList(db.TipoEquipo, "idTE", "nombreTE", equipo.idTE);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
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
