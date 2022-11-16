using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Models.ViewModels
{
    public class ModeloCatalogoAccesorios
    {

        //=======================================================
        [Required(ErrorMessage = "Debe digitar el id del accesorio")]
        [IdAccesorioExiste]
        [Display(Name = "Id Accesorios")]
        public int ID_CATALOGO_ACCESORIO { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el nombre del accesorio")]
        public string NOM_ACCESORIO { get; set; }

        //==============================================================
        [Required(ErrorMessage = "Debe digitar la marca del accesorio")]
        public string MARCA { get; set; }

        //===============================================================
        [Required(ErrorMessage = "Debe digitar la descripcion del accesorio")]
        public string DESCRIPCION { get; set; }

        //================================================================
        [Required(ErrorMessage = "Debe digitar el precio del accesorio")]
        public decimal PRECIO_ACCESORIO { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el ID del producto")]
        public int ID_PRODUCTO { get; set; }

        //==============================================
        public virtual PRODUCTOS PRODUCTOS { get; set; }



    }

    public class IdAccesorioExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                int id = (int)value;
                if (db.CATALOGO_ACCESORIOS.Where(a => a.ID_CATALOGO_ACCESORIO == id).Count() > 0)
                {
                    return new ValidationResult("Ya existe ese accesorio");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }

}