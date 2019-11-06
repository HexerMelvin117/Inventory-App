//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquiposInvWM
{
    using System;
    using System.Collections.Generic;
    
    public partial class FichaComputo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FichaComputo()
        {
            this.ListaPerifericos = new HashSet<ListaPerifericos>();
        }
    
        public int ficha_id { get; set; }
        public string ficha_emp { get; set; }
        public Nullable<System.DateTime> ficha_fecha { get; set; }
        public string ficha_dpto { get; set; }
        public string ficha_pyto { get; set; }
        public Nullable<int> emp_id { get; set; }
        public string emp_nom { get; set; }
        public string emp_cod { get; set; }
        public string equi_cod { get; set; }
        public Nullable<int> equi_id { get; set; }
        public string equi_marca { get; set; }
        public string equi_serie { get; set; }
        public string equi_procesador { get; set; }
        public Nullable<decimal> equi_ghz { get; set; }
        public Nullable<int> equi_disco { get; set; }
        public string ficha_sysope { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Equipos Equipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaPerifericos> ListaPerifericos { get; set; }
    }
}