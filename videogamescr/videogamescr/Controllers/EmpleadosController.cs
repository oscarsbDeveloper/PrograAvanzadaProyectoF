using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videogamescr.Models;
using videogamescr.Clases;

namespace videogamescr.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados

        Employee employee = new Employee();
        public ActionResult Index()
        {
            IEnumerable<EMPLEADOS> lst = employee.Consultar();
            return View(lst);
        }

        public ActionResult Guardar(EMPLEADOS modelo)
        {
            ViewBag.Mensaje = "";

            return View(modelo);
        }

        public ActionResult Nuevo(EMPLEADOS modelo)
        {
            employee.Guardar(modelo);
            ViewBag.Mensaje = "El empleado se agrego correctamente,";
            return View("Guardar", modelo);
        }
        public ActionResult Modificar(int id)
        {
            EMPLEADOS modelo = employee.Consultar(id);
            ViewBag.Mensaje = "";
            return View(modelo);
        }
        public ActionResult Cambiar(EMPLEADOS modelo)
        {
            employee.Modificar(modelo);
            ViewBag.Mensaje = "El empleado se modifico correctamente.";
            return View("Modificar", modelo);
        }
        public ActionResult Detalle(int id)
        {
            EMPLEADOS modelo = employee.Consultar(id);
            return View(modelo);
        }

        public ActionResult Eliminar(int id)
        {
            EMPLEADOS modelo = new EMPLEADOS()
            {
                ID_EMPLEADO = id
            };
            employee.Eliminar(modelo);
            ViewBag.Mensaje = "El empleado se elimino correctamente.";
            IEnumerable<EMPLEADOS> lst = employee.Consultar();
            return View("Index", lst);
        }


    }
}