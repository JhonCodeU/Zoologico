﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZooEntities1 : DbContext
    {
        public ZooEntities1()
            : base("name=ZooEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AtiendeParqueadero> AtiendeParqueaderoes { get; set; }
        public virtual DbSet<cita> citas { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<compra> compras { get; set; }
        public virtual DbSet<modulo> moduloes { get; set; }
        public virtual DbSet<operacione> operaciones { get; set; }
        public virtual DbSet<parqueadero> parqueaderoes { get; set; }
        public virtual DbSet<planTuristico> planTuristicoes { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<rol_operacion> rol_operacion { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TipoAnimal> TipoAnimals { get; set; }
        public virtual DbSet<trabajador> trabajadors { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<vehiculo> vehiculoes { get; set; }
        public virtual DbSet<veterinario> veterinarios { get; set; }
        public virtual DbSet<ZonaGeografica> ZonaGeograficas { get; set; }
        public virtual DbSet<Zoologico> Zoologicoes { get; set; }
    }
}
