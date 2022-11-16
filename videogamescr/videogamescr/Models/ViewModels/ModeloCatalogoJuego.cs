using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Models.ViewModels
{
    public class ModeloCatalogoJuego
    {
        //=======================================================
       
       
        [Display(Name = "Id Juegos")]
        [Required(ErrorMessage = "Debe digitar el id del juego")]
        [IdJuegoExiste]
        public int ID_CATALOGO_JUEGO { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el Nombre del juego")]
        public string NOM_JUEGO { get; set; }

        //==============================================================
        [Required(ErrorMessage = "Debe digitar la categoria del juego")]
        public string CATEGORIA { get; set; }

        //===============================================================
        [Required(ErrorMessage = "Debe digitar la plataforma del juego")]
        public string PLATAFORMA { get; set; }

        //================================================================
        [Required(ErrorMessage = "Debe digitar la descripcion del juego")]
        public string DESCRIPCION { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el precio del juego")]
        public decimal PRECIO_JUEGO { get; set; }

        //================================================================
        [Required(ErrorMessage = "Debe digitar el tipo de producto (ID)")]
        public int ID_PRODUCTO { get; set; }

        //==============================================
        public virtual PRODUCTOS PRODUCTOS { get; set; }

    }

    public class IdJuegoExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                int id = (int)value;
                if (db.CATALOGO_JUEGOS.Where(a => a.ID_CATALOGO_JUEGO == id).Count() > 0)
                {
                    return new ValidationResult("Ya existe ese empleado");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }

}