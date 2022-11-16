using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Clases
{
    public class CatalogoAccesorios
    {

        //===========================================================
        //   Metodo para consultar los datos del Modelo de la BD
        //===========================================================
        public IEnumerable<CATALOGO_ACCESORIOS> Consultar()
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_ACCESORIOS.ToList();
            }
        }

        //======================================================
        //   Metodo para Modificar los datos del Modelo de la BD
        //======================================================
        public void Modificar(CATALOGO_ACCESORIOS model)
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
        public CATALOGO_ACCESORIOS Consultar(int id)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_ACCESORIOS.FirstOrDefault(x => x.ID_CATALOGO_ACCESORIO == id);
            }
        }

        //====================================================
        //   Metodo para Borrar un dato seleccionado por el ID
        //====================================================
        public void Eliminar(CATALOGO_ACCESORIOS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.CATALOGO_ACCESORIOS.Remove(modelo);
                db.SaveChanges();
            }
        }

    }
}