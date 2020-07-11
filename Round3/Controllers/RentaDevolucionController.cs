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
    public class RentaDevolucionController : Controller
    {
        private UNAPEC_PRESTAMOEntitie db = new UNAPEC_PRESTAMOEntitie();

        // GET: RentaDevolucion
        public ActionResult Index()
        {
            var rentaDevolucion = db.RentaDevolucion.Include(r => r.Empleado).Include(r => r.Equipo).Include(r => r.Usuario);
            return View(rentaDevolucion.ToList());
        }

        // GET: RentaDevolucion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaDevolucion rentaDevolucion = db.RentaDevolucion.Find(id);
            if (rentaDevolucion == null)
            {
                return HttpNotFound();
            }
            return View(rentaDevolucion);
        }

        // GET: RentaDevolucion/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombreEmpleado");
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombreEquipo");
            ViewBag.idUsuadio = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: RentaDevolucion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "noPrestamo,idEmpleado,idEquipo,idUsuadio,fechaP,fechaD,comentario,estadoPrestamo")] RentaDevolucion rentaDevolucion)
        {
            if (ModelState.IsValid)
            {
                db.RentaDevolucion.Add(rentaDevolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombreEmpleado", rentaDevolucion.idEmpleado);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombreEquipo", rentaDevolucion.idEquipo);
            ViewBag.idUsuadio = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", rentaDevolucion.idUsuadio);
            return View(rentaDevolucion);
        }

        // GET: RentaDevolucion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaDevolucion rentaDevolucion = db.RentaDevolucion.Find(id);
            if (rentaDevolucion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombreEmpleado", rentaDevolucion.idEmpleado);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombreEquipo", rentaDevolucion.idEquipo);
            ViewBag.idUsuadio = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", rentaDevolucion.idUsuadio);
            return View(rentaDevolucion);
        }

        // POST: RentaDevolucion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "noPrestamo,idEmpleado,idEquipo,idUsuadio,fechaP,fechaD,comentario,estadoPrestamo")] RentaDevolucion rentaDevolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentaDevolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombreEmpleado", rentaDevolucion.idEmpleado);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombreEquipo", rentaDevolucion.idEquipo);
            ViewBag.idUsuadio = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", rentaDevolucion.idUsuadio);
            return View(rentaDevolucion);
        }

        // GET: RentaDevolucion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaDevolucion rentaDevolucion = db.RentaDevolucion.Find(id);
            if (rentaDevolucion == null)
            {
                return HttpNotFound();
            }
            return View(rentaDevolucion);
        }

        // POST: RentaDevolucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentaDevolucion rentaDevolucion = db.RentaDevolucion.Find(id);
            db.RentaDevolucion.Remove(rentaDevolucion);
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
