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
            //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseInMemoryDatabase(databaseName: "CesarEdu");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CollaboratorMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
        }

    }
}