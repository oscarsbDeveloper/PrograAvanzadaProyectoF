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
    public class AYUDA_CLIENTESController : Controller
    {
        private gamestorecrEntities db = new gamestorecrEntities();

        // GET: AYUDA_CLIENTES
        public ActionResult Index()
        {
            var aYUDA_CLIENTES = db.AYUDA_CLIENTES.Include(a => a.CLIENTES);
            return View(aYUDA_CLIENTES.ToList());
        }

        // GET: AYUDA_CLIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYUDA_CLIENTES aYUDA_CLIENTES = db.AYUDA_CLIENTES.Find(id);
            if (aYUDA_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(aYUDA_CLIENTES);
        }

        // GET: AYUDA_CLIENTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOM_CLIENTE");
            return View();
        }

        // POST: AYUDA_CLIENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_AYUDA,TITULO_ASUNTO,MENSAJE,ID_CLIENTE")] AYUDA_CLIENTES aYUDA_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.AYUDA_CLIENTES.Add(aYUDA_CLIENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOM_CLIENTE", aYUDA_CLIENTES.ID_CLIENTE);
            return View(aYUDA_CLIENTES);
        }

        // GET: AYUDA_CLIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYUDA_CLIENTES aYUDA_CLIENTES = db.AYUDA_CLIENTES.Find(id);
            if (aYUDA_CLIENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOM_CLIENTE", aYUDA_CLIENTES.ID_CLIENTE);
            return View(aYUDA_CLIENTES);
        }

        // POST: AYUDA_CLIENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AYUDA,TITULO_ASUNTO,MENSAJE,ID_CLIENTE")] AYUDA_CLIENTES aYUDA_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aYUDA_CLIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOM_CLIENTE", aYUDA_CLIENTES.ID_CLIENTE);
            return View(aYUDA_CLIENTES);
        }

        // GET: AYUDA_CLIENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYUDA_CLIENTES aYUDA_CLIENTES = db.AYUDA_CLIENTES.Find(id);
            if (aYUDA_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(aYUDA_CLIENTES);
        }

        // POST: AYUDA_CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AYUDA_CLIENTES aYUDA_CLIENTES = db.AYUDA_CLIENTES.Find(id);
            db.AYUDA_CLIENTES.Remove(aYUDA_CLIENTES);
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
