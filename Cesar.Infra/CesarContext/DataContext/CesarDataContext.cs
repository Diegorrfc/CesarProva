using Cesar.Domain.CesarContext.Entities;
using Cesar.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cesar.Infra.CesarContext.DataContext
{
    public class CesarDataContext : DbContext
    { 
        public CesarDataContext(DbContextOptions<CesarDataContext> options) : base(options)
        {
        }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Address> Address { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseInMemoryDatabase(databaseName: "CesarEdu");
                    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CollaboratorMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
        }

    }
}