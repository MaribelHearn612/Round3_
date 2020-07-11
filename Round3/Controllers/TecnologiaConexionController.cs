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
    public class TecnologiaConexionController : Controller
    {
        private UNAPEC_PRESTAMOEntitie db = new UNAPEC_PRESTAMOEntitie();

        // GET: TecnologiaConexion
        public ActionResult Index()
        {
            return View(db.TecnologiaConexion.ToList());
        }

        // GET: TecnologiaConexion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnologiaConexion tecnologiaConexion = db.TecnologiaConexion.Find(id);
            if (tecnologiaConexion == null)
            {
                return HttpNotFound();
            }
            return View(tecnologiaConexion);
        }

        // GET: TecnologiaConexion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TecnologiaConexion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTC,nombreTC,descripcionTC,estadoTC")] TecnologiaConexion tecnologiaConexion)
        {
            if (ModelState.IsValid)
            {
                db.TecnologiaConexion.Add(tecnologiaConexion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnologiaConexion);
        }

        // GET: TecnologiaConexion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnologiaConexion tecnologiaConexion = db.TecnologiaConexion.Find(id);
            if (tecnologiaConexion == null)
            {
                return HttpNotFound();
            }
            return View(tecnologiaConexion);
        }

        // POST: TecnologiaConexion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTC,nombreTC,descripcionTC,estadoTC")] TecnologiaConexion tecnologiaConexion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnologiaConexion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnologiaConexion);
        }

        // GET: TecnologiaConexion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnologiaConexion tecnologiaConexion = db.TecnologiaConexion.Find(id);
            if (tecnologiaConexion == null)
            {
                return HttpNotFound();
            }
            return View(tecnologiaConexion);
        }

        // POST: TecnologiaConexion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TecnologiaConexion tecnologiaConexion = db.TecnologiaConexion.Find(id);
            db.TecnologiaConexion.Remove(tecnologiaConexion);
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
