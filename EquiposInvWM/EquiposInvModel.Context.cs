﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EquiposInvModelContainer : DbContext
    {
        public EquiposInvModelContainer()
            : base("name=EquiposInvModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Compania> Compania { get; set; }
        public virtual DbSet<Devoluciones> Devoluciones { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<FichaComputo> FichaComputo { get; set; }
        public virtual DbSet<ImagenEquipo> ImagenEquipo { get; set; }
        public virtual DbSet<ImagenesDevolucion> ImagenesDevolucion { get; set; }
        public virtual DbSet<ListaPerifericos> ListaPerifericos { get; set; }
        public virtual DbSet<ListaPerifericosDevo> ListaPerifericosDevo { get; set; }
        public virtual DbSet<Perifericos> Perifericos { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<SoftwareInstalado> SoftwareInstalado { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
