﻿// <auto-generated />
using System;
using Crm.Server.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crm.Server.Infrastructure.Database.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    partial class CrmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Crm.Domain.Models.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuditTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuditTypeId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Crm.Domain.Models.AuditType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("AuditTypes");
                });

            modelBuilder.Entity("Crm.Domain.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contact")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("34948bab-fde2-42d7-8d6f-7303b0e0af9e"),
                            Contact = "+79455684645",
                            Name = "Irina Victorovna"
                        },
                        new
                        {
                            Id = new Guid("04421f24-fb3e-49f0-bc2a-d519d7856b25"),
                            Contact = "ivanovich.a@mail.ru",
                            Name = "Alexander Ivanovich"
                        });
                });

            modelBuilder.Entity("Crm.Domain.Models.ClientManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ClientManagers");
                });

            modelBuilder.Entity("Crm.Domain.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Crm.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contact")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Crm.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Crm.Domain.Models.OrderResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ResourceId");

                    b.ToTable("OrderResources");
                });

            modelBuilder.Entity("Crm.Domain.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Crm.Domain.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Crm.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("HashedPassword")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Salt")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Crm.Domain.Models.AuditLog", b =>
                {
                    b.HasOne("Crm.Domain.Models.AuditType", "Type")
                        .WithMany("AuditLogs")
                        .HasForeignKey("AuditTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Crm.Domain.Models.ClientManager", b =>
                {
                    b.HasOne("Crm.Domain.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Crm.Domain.Models.Department", b =>
                {
                    b.HasOne("Crm.Domain.Models.Department", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Crm.Domain.Models.Employee", b =>
                {
                    b.HasOne("Crm.Domain.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Crm.Domain.Models.Order", b =>
                {
                    b.HasOne("Crm.Domain.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Crm.Domain.Models.OrderResource", b =>
                {
                    b.HasOne("Crm.Domain.Models.Order", "Order")
                        .WithMany("Resources")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Crm.Domain.Models.Task", b =>
                {
                    b.HasOne("Crm.Domain.Models.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.Order", "Order")
                        .WithMany("Tasks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Crm.Domain.Models.User", b =>
                {
                    b.HasOne("Crm.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Crm.Domain.Models.AuditType", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("Crm.Domain.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Crm.Domain.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Crm.Domain.Models.Employee", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Crm.Domain.Models.Order", b =>
                {
                    b.Navigation("Resources");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}