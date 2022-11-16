using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Clases
{
    public class CatalogoJuegos
    {
        //===========================================================
        //   Metodo para consultar los datos del Modelo de la BD
        //===========================================================
        public IEnumerable<CATALOGO_JUEGOS> Consultar()
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_JUEGOS.ToList();
            }
        }

        //======================================================
        //   Metodo para Modificar los datos del Modelo de la BD
        //======================================================
        public void Modificar(CATALOGO_JUEGOS model)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //==================================================================
        //   Metodo para Consultar el dato del Modelo de la BD para editarlo
        //==================================================================
        public CATALOGO_JUEGOS Consultar(int id)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_JUEGOS.FirstOrDefault(x => x.ID_CATALOGO_JUEGO == id);
            }
        }

        //====================================================
        //   Metodo para Borrar un dato seleccionado por el ID
        //====================================================
        public void Eliminar(CATALOGO_JUEGOS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.CATALOGO_JUEGOS.Remove(modelo);
                db.SaveChanges();
            }
        }

    }
}