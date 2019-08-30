using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cesar.Infra.EntityConfig
{
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedNever();
                  
            

            builder.OwnsOne(m => m.Name, a =>
            {
                a.Property(p => p.FirstName).HasMaxLength(Name.Constraints.MaxLengthFirstName)
                    .HasColumnName("FirstName")
                    .HasDefaultValue("");
                a.Property(p => p.LastName).HasMaxLength(Name.Constraints.MaxLengthLastName)
                    .HasColumnName("LastName")
                    .HasDefaultValue("");

            });
            
            builder.OwnsOne(m => m.Document, a =>
            {
                a.Property(p => p.Number).HasMaxLength(Document.Constraints.LengthDocument)
                    .HasColumnName("DocumentNumber")
                    .HasDefaultValue("");

            });
            builder.OwnsOne(m => m.Email, a =>
            {
                a.Property(p => p.Address).HasMaxLength(Email.Constraints.LengthEmail)
                    .HasColumnName("Email")
                    .HasDefaultValue("");

            });
            builder.OwnsOne(m => m.Phone, a =>
            {
                a.Property(p => p.PhoneNumber).HasMaxLength(Phone.Constraints.MaximumLengthNumber)
                    .HasColumnName("PhoneNumber")
                    .HasDefaultValue("");

            });          
            


        }
    }
}
