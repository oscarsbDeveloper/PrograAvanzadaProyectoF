using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Clases
{
    public class Employee
    {
        public IEnumerable<EMPLEADOS> Consultar()
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.EMPLEADOS.ToList();
            }
        }

        public void Guardar(EMPLEADOS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.EMPLEADOS.Add(modelo);
                db.SaveChanges();

            }

        }
        public void Modificar(EMPLEADOS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        public void Eliminar(EMPLEADOS modelo)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.EMPLEADOS.Remove(modelo);
                db.SaveChanges();

            }

        }

        public EMPLEADOS Consultar(int id)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                return db.EMPLEADOS.FirstOrDefault(x => x.ID_EMPLEADO == id);

            }
        }


    }
}