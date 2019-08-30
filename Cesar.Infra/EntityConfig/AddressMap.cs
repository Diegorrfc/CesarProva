using Cesar.Domain.CesarContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cesar.Infra.EntityConfig
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(prop => prop.City)
                .HasMaxLength(Address.Constraints.MaximumLengthCity);
            builder.Property(prop => prop.Number)
               .HasMaxLength(Address.Constraints.MaximumLengthNumber);
            builder.Property(prop => prop.District)
               .HasMaxLength(Address.Constraints.MaximumLengthDistrict);
            builder.Property(prop => prop.City)
               .HasMaxLength(Address.Constraints.MaximumLengthCity);
            builder.Property(prop => prop.Country)
               .HasMaxLength(Address.Constraints.MaximumLengthCountry);
            builder.Property(prop => prop.ZipCode)
              .HasMaxLength(Address.Constraints.MaximumLengthZipCode);
            builder.HasOne(m => m.Collaborator)
                .WithOne(n => n.Address).HasForeignKey<Collaborator>(n=>n.IdAddress)
            .OnDelete(DeleteBehavior.Restrict);
           
        }
}
}