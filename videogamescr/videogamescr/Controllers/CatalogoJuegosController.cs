using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videogamescr.Models;
using videogamescr.Clases;

namespace videogamescr.Controllers
{
    
    public class CatalogoJuegosController : Controller
    {
        gamestorecrEntities db = new gamestorecrEntities();
        CatalogoJuegos cj = new CatalogoJuegos();

        //=======================================================
        //Metodo para visualizar los datos del Catalogo de Juegos
        //=======================================================
        public ActionResult Index()
        {
            IEnumerable<CATALOGO_JUEGOS> lst = cj.Consultar();
            return View(lst);
        }

        //======================================
        //Metodo para Cargar la vista de Guardar
        //======================================
        public ActionResult GuardarJuego(videogamescr.Models.ViewModels.ModeloCatalogoJuego model)
        {
            if (model == null)
                model = new videogamescr.Models.ViewModels.ModeloCatalogoJuego();
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
        public ActionResult Guardar(videogamescr.Models.ViewModels.ModeloCatalogoJuego model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }
            CATALOGO_JUEGOS cj = new CATALOGO_JUEGOS();
            cj.ID_CATALOGO_JUEGO = model.ID_CATALOGO_JUEGO;
            cj.NOM_JUEGO = model.NOM_JUEGO;
            cj.CATEGORIA = model.CATEGORIA;
            cj.PLATAFORMA = model.PLATAFORMA;
            cj.DESCRIPCION = model.DESCRIPCION;
            cj.PRECIO_JUEGO = model.PRECIO_JUEGO;
            cj.ID_PRODUCTO = model.ID_PRODUCTO;
            cj.PRODUCTOS = model.PRODUCTOS;
            db.CATALOGO_JUEGOS.Add(cj);
            db.SaveChanges();

            return RedirectToAction("Exito", model);
        }

    }
}