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
        public IEnumerable<CATALOGO_JUEGOS>Consultar()
        {
            using(gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.CATALOGO_JUEGOS.ToList();
            }
        }
            

    }
}