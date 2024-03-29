﻿// <auto-generated />
using System;
using Cesar.Infra.CesarContext.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cesar.Infra.Migrations
{
    [DbContext(typeof(CesarDataContext))]
    [Migration("20190828041013_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("Cesar.Domain.CesarContext.Entities.Address", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("City")
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .HasMaxLength(15);

                    b.Property<string>("District")
                        .HasMaxLength(15);

                    b.Property<Guid>("IdCollaborator");

                    b.Property<string>("Number")
                        .HasMaxLength(12);

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("IdCollaborator")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Cesar.Domain.CesarContext.Entities.Collaborator", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("IdAddress");

                    b.Property<string>("JobTitle");

                    b.Property<string>("ProjectName");

                    b.Property<decimal>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("Cesar.Domain.CesarContext.Entities.Address", b =>
                {
                    b.HasOne("Cesar.Domain.CesarContext.Entities.Collaborator", "Collaborator")
                        .WithOne("Address")
                        .HasForeignKey("Cesar.Domain.CesarContext.Entities.Address", "IdCollaborator")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Cesar.Domain.CesarContext.Entities.Collaborator", b =>
                {
                    b.OwnsOne("Cesar.Domain.CesarContext.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid?>("CollaboratorId");

                            b1.Property<string>("Number")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DocumentNumber")
                                .HasMaxLength(11)
                                .HasDefaultValue("");

                            b1.ToTable("Collaborator");

                            b1.HasOne("Cesar.Domain.CesarContext.Entities.Collaborator")
                                .WithOne("Document")
                                .HasForeignKey("Cesar.Domain.CesarContext.ValueObjects.Document", "CollaboratorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Cesar.Domain.CesarContext.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid?>("CollaboratorId");

                            b1.Property<string>("Address")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Email")
                                .HasMaxLength(500)
                                .HasDefaultValue("");

                            b1.ToTable("Collaborator");

                            b1.HasOne("Cesar.Domain.CesarContext.Entities.Collaborator")
                                .WithOne("Email")
                                .HasForeignKey("Cesar.Domain.CesarContext.ValueObjects.Email", "CollaboratorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Cesar.Domain.CesarContext.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("CollaboratorId");

                            b1.Property<string>("FirstName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("FirstName")
                                .HasMaxLength(15)
                                .HasDefaultValue("");

                            b1.Property<string>("LastName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("LastName")
                                .HasMaxLength(30)
                                .HasDefaultValue("");

                            b1.ToTable("Collaborator");

                            b1.HasOne("Cesar.Domain.CesarContext.Entities.Collaborator")
                                .WithOne("Name")
                                .HasForeignKey("Cesar.Domain.CesarContext.ValueObjects.Name", "CollaboratorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Cesar.Domain.CesarContext.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid?>("CollaboratorId");

                            b1.Property<string>("PhoneNumber")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("PhoneNumber")
                                .HasMaxLength(12)
                                .HasDefaultValue("");

                            b1.ToTable("Collaborator");

                            b1.HasOne("Cesar.Domain.CesarContext.Entities.Collaborator")
                                .WithOne("Phone")
                                .HasForeignKey("Cesar.Domain.CesarContext.ValueObjects.Phone", "CollaboratorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
