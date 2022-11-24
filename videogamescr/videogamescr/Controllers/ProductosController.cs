using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using videogamescr.Models;

namespace videogamescr.Controllers
{
    public class PRODUCTOSController : Controller
    {
        private gamestorecrEntities db = new gamestorecrEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            return View(db.PRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUCTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,TIPO_PRODUCTO,PLATAFORMA,DESCRIPCION")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,TIPO_PRODUCTO,PLATAFORMA,DESCRIPCION")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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
