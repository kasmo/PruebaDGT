﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaDGT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DGTEntities : DbContext
    {
        public DGTEntities()
            : base("name=DGTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<ConductorVehiculo> ConductorVehiculo { get; set; }
        public virtual DbSet<Infracciones> Infracciones { get; set; }
        public virtual DbSet<InfraccionVehiculo> InfraccionVehiculo { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
