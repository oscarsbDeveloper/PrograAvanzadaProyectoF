//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace videogamescr.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FACTURAS
    {
        public int ID_FACTURAS { get; set; }
        public int NUM_FACTURA { get; set; }
        public System.DateTime FECHA { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_EMPLEADO { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_VENTA { get; set; }
    
        public virtual CLIENTES CLIENTES { get; set; }
        public virtual EMPLEADOS EMPLEADOS { get; set; }
        public virtual PRODUCTOS PRODUCTOS { get; set; }
        public virtual VENTAS VENTAS { get; set; }
    }
}