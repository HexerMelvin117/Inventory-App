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
    
    public partial class SoftwareInstalado
    {
        public int softinstal_id { get; set; }
        public string softinstal_nom { get; set; }
        public Nullable<bool> softinstal_instalado { get; set; }
        public Nullable<int> ficha_id { get; set; }
    
        public virtual FichaComputo FichaComputo { get; set; }
    }
}
