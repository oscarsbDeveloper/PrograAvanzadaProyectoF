using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using videogamescr.Models;

namespace videogamescr.Models.ViewModels
{
    public class ModeloCatalogoConsolas
    {
        //=======================================================
        [Required(ErrorMessage = "Debe digitar el id de la consola")]
        [IdConsolaExiste]
        [Display(Name = "Id Consolas")]
        public int ID_CATALOGO_CONSOLA { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el nombre de la consola")]
        public string NOM_CONSOLA { get; set; }

        //==============================================================
        [Required(ErrorMessage = "Debe digitar la marca de la consola")]
        public string MARCA { get; set; }

        //===============================================================
        [Required(ErrorMessage = "Debe digitar la descripcion de la consola")]
        public string DESCRIPCION { get; set; }

        //================================================================
        [Required(ErrorMessage = "Debe digitar el precio de la consola")]
        public decimal PRECIO_CONSOLA { get; set; }

        //===========================================================
        [Required(ErrorMessage = "Debe digitar el ID de la consola")]
        public int ID_PRODUCTO { get; set; }

        //==============================================
        public virtual PRODUCTOS PRODUCTOS { get; set; }










    }

    public class IdConsolaExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (gamestorecrEntities db = new gamestorecrEntities())
            {
                int id = (int)value;
                if (db.CATALOGO_CONSOLAS.Where(a => a.ID_CATALOGO_CONSOLA == id).Count() > 0)
                {
                    return new ValidationResult("Ya existe esa consola");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }

}