//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquiposInvWM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table
    {
        public int orden_id { get; set; }
        public string orden_tipo { get; set; }
        public string orden_desc { get; set; }
        public string orden_proy { get; set; }
        public string orden_proveedor { get; set; }
        public string orden_numfactura { get; set; }
        public Nullable<System.DateTime> orden_garantia { get; set; }
        public Nullable<decimal> orden_precio { get; set; }
    }
}
