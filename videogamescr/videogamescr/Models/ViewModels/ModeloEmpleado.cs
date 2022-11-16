using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace videogamescr.Models.ViewModels
{
    public class ModeloEmpleado
    {
        [Required(ErrorMessage = "Debe digitar un codigo de empleado")]
        [Display(Name = "Codigo Empleado")]
        [CodigoExiste]
        public int ID_EMPLEADO { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del juego")]
        [StringLength(20, ErrorMessage = "El tamaño no debe superar los 20 caracteres")]
        public string NOM_EMPLEADO { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del juego")]
        [StringLength(20, ErrorMessage = "El tamaño no debe superar los 20 caracteres")]
        public string APELLIDO_EMPLEADO { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del juego")]
        [StringLength(15, ErrorMessage = "El tamaño no debe superar los 15 caracteres")]
        public string PUESTO { get; set; }
    }
    public class CodigoExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {

                int codigo_empleado = (int)value;
                if (db.EMPLEADOS.Where(d => d.ID_EMPLEADO == codigo_empleado).Count() > 0)
                    return new ValidationResult("Empleado ya existe");
            }
            return ValidationResult.Success;
        }
    }

}