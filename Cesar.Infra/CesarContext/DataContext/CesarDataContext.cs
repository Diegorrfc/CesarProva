using Cesar.Domain.CesarContext.Entities;
using Cesar.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Cesar.Infra.CesarContext.DataContext
{
    public class CesarDataContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var opt = optionsBuilder.UseSqlite("DataSource=:memory:").Options;
        }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Address> Address { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CollaboratorMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            
        }

        }
}