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
    
    public partial class ListaPerifericosDevo
    {
        public int devoperlist_id { get; set; }
        public int per_id { get; set; }
        public int devo_id { get; set; }
    
        public virtual Devoluciones Devoluciones { get; set; }
    }
}
