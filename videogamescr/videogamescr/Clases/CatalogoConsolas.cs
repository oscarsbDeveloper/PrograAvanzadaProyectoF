using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Clases
{
    public class CatalogoConsolas
    {
        //===========================================================
        //   Metodo para consultar los datos del Modelo de la BD
        //===========================================================
        public IEnumerable<CATALOGO_CONSOLAS> Consultar()
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_CONSOLAS.ToList();
            }
        }

        //======================================================
        //   Metodo para Modificar los datos del Modelo de la BD
        //======================================================
        public void Modificar(CATALOGO_CONSOLAS model)
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
        public CATALOGO_CONSOLAS Consultar(int id)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_CONSOLAS.FirstOrDefault(x => x.ID_CATALOGO_CONSOLA == id);
            }
        }

        //====================================================
        //   Metodo para Borrar un dato seleccionado por el ID
        //====================================================
        public void Eliminar(CATALOGO_CONSOLAS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.CATALOGO_CONSOLAS.Remove(modelo);
                db.SaveChanges();
            }
        }

    }
}