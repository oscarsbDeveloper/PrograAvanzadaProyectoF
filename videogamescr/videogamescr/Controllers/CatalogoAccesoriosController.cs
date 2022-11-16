using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videogamescr.Models;
using videogamescr.Clases;

namespace videogamescr.Controllers
{
    public class CatalogoAccesoriosController : Controller
    {

        gamestorecrEntities db = new gamestorecrEntities();
        CatalogoAccesorios ca = new CatalogoAccesorios();
        // GET: CatalogoAccesorios
        public ActionResult Index()
        {
            IEnumerable<CATALOGO_ACCESORIOS> lst = ca.Consultar();
            return View(lst);
        }

        //======================================
        //Metodo para Cargar la vista de Guardar
        //======================================
        public ActionResult GuardarAccesorio(videogamescr.Models.ViewModels.ModeloCatalogoAccesorios model)
        {
            if (model == null)
                model = new videogamescr.Models.ViewModels.ModeloCatalogoAccesorios();
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
        public ActionResult Guardar(videogamescr.Models.ViewModels.ModeloCatalogoAccesorios model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }
            CATALOGO_ACCESORIOS ca = new CATALOGO_ACCESORIOS();
            ca.ID_CATALOGO_ACCESORIO = model.ID_CATALOGO_ACCESORIO;
            ca.NOM_ACCESORIO = model.NOM_ACCESORIO;
            ca.MARCA = model.MARCA;
            ca.DESCRIPCION = model.DESCRIPCION;
            ca.PRECIO_ACCESORIO = model.PRECIO_ACCESORIO;
            ca.ID_PRODUCTO = model.ID_PRODUCTO;
            ca.PRODUCTOS = model.PRODUCTOS;
            db.CATALOGO_ACCESORIOS.Add(ca);
            db.SaveChanges();

            return RedirectToAction("Exito", model);
        }

        //================================================
        //Metodo para consultar el dato que se va a editar
        //================================================
        public ActionResult Modificar(int id)
        {
            CATALOGO_ACCESORIOS modelo = ca.Consultar(id);
            ViewBag.Mensaje = "";
            return View(modelo);
        }

        //================================================================
        //Metodo para editar el dato que se consulto en el metodo anterior
        //================================================================
        public ActionResult Cambiar(CATALOGO_ACCESORIOS modelo)
        {
            ca.Modificar(modelo);
            ViewBag.Mensaje = "El accesorio se modifico correctamente";
            return View("Modificar", modelo);
        }

        //====================================================
        //Metodo para consultar la linea seleccionada de datos
        //====================================================
        public ActionResult Detalle(int id)
        {
            CATALOGO_ACCESORIOS modelo = ca.Consultar(id);
            return View(modelo);
        }

        public ActionResult Eliminar(int id)
        {
            CATALOGO_ACCESORIOS modelo = new CATALOGO_ACCESORIOS()
            {
                ID_CATALOGO_ACCESORIO = id
            };
            ca.Eliminar(modelo);
            ViewBag.Mensaje = "El accesorio se elimino correctamente";
            IEnumerable<CATALOGO_ACCESORIOS> lst = ca.Consultar();
            return View("Index", lst);

        }

    }
}