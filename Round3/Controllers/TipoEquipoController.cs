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
    public class TipoEquipoController : Controller
    {
        private UNAPEC_PRESTAMOEntitie db = new UNAPEC_PRESTAMOEntitie();

        // GET: TipoEquipo
        public ActionResult Index()
        {
            return View(db.TipoEquipo.ToList());
        }

        // GET: TipoEquipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTE,nombreTE,descripcionTE,estadoTE")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTE,nombreTE,descripcionTE,estadoTE")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            db.TipoEquipo.Remove(tipoEquipo);
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
