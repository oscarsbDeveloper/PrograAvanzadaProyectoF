using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videogamescr.Models;
using videogamescr.Clases;

namespace videogamescr.Controllers
{
    public class CatalogoConsolasController : Controller
    {

        gamestorecrEntities db = new gamestorecrEntities();
        CatalogoConsolas cc = new CatalogoConsolas();
        // GET: CatalogoConsolas
        public ActionResult Index()
        {
            IEnumerable<CATALOGO_CONSOLAS> lst = cc.Consultar();
            return View(lst);
        }

        //======================================
        //Metodo para Cargar la vista de Guardar
        //======================================
        public ActionResult GuardarConsola(videogamescr.Models.ViewModels.ModeloCatalogoConsolas model)
        {
            if (model == null)
                model = new videogamescr.Models.ViewModels.ModeloCatalogoConsolas();
            return View();
        }

        //====================================
        //Metodo para Cargar la vista de Exito
        //====================================
        public ActionResult Exito()
        {
            return View();
        }

        //=================================================
        //Metodo para Insertar datos del Catalogo de Juegos
        //=================================================
        public ActionResult Guardar(videogamescr.Models.ViewModels.ModeloCatalogoConsolas model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }
            CATALOGO_CONSOLAS cc = new CATALOGO_CONSOLAS();
            cc.ID_CATALOGO_CONSOLA = model.ID_CATALOGO_CONSOLA;
            cc.NOM_CONSOLA = model.NOM_CONSOLA;
            cc.MARCA = model.MARCA;
            cc.DESCRIPCION = model.DESCRIPCION;
            cc.PRECIO_CONSOLA = model.PRECIO_CONSOLA;
            cc.ID_PRODUCTO = model.ID_PRODUCTO;
            cc.PRODUCTOS = model.PRODUCTOS;
            db.CATALOGO_CONSOLAS.Add(cc);
            db.SaveChanges();

            return RedirectToAction("Exito", model);
        }

        //================================================
        //Metodo para consultar el dato que se va a editar
        //================================================
        public ActionResult Modificar(int id)
        {
            CATALOGO_CONSOLAS modelo = cc.Consultar(id);
            ViewBag.Mensaje = "";
            return View(modelo);
        }

        //================================================================
        //Metodo para editar el dato que se consulto en el metodo anterior
        //================================================================
        public ActionResult Cambiar(CATALOGO_CONSOLAS modelo)
        {
            cc.Modificar(modelo);
            ViewBag.Mensaje = "La consola se modifico correctamente";
            return View("Modificar", modelo);
        }

        //====================================================
        //Metodo para consultar la linea seleccionada de datos
        //====================================================
        public ActionResult Detalle(int id)
        {
            CATALOGO_CONSOLAS modelo = cc.Consultar(id);
            return View(modelo);
        }

        public ActionResult Eliminar(int id)
        {
            CATALOGO_CONSOLAS modelo = new CATALOGO_CONSOLAS()
            {
                ID_CATALOGO_CONSOLA = id
            };
            cc.Eliminar(modelo);
            ViewBag.Mensaje = "La consola se elimino correctamente";
            IEnumerable<CATALOGO_CONSOLAS> lst = cc.Consultar();
            return View("Index", lst);

        }

    }
}