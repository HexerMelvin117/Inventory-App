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
    
    public partial class ImagenesDevolucion
    {
        public int imgdevo_id { get; set; }
        public string imgdevo_name { get; set; }
        public string imgdevo_path { get; set; }
        public Nullable<int> devo_id { get; set; }
    
        public virtual Devoluciones Devoluciones { get; set; }
    }
}
