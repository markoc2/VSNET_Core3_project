﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VBNET_Core3_project.Data;

namespace VBNET_Core3_project.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220212213036_migracion-marko-te-presta")]
    partial class migracionmarkotepresta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VBNET_Core3_project.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("IdCliente");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("VBNET_Core3_project.Models.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoPagado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PagosFK")
                        .HasColumnType("int");

                    b.HasKey("IdPago");

                    b.HasIndex("PagosFK");

                    b.ToTable("pagos");
                });

            modelBuilder.Entity("VBNET_Core3_project.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPrestamo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<decimal>("Interes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Plazo")
                        .HasColumnType("int");

                    b.Property<int?>("PrestamosFK")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("PrestamosFK");

                    b.ToTable("prestamos");
                });

            modelBuilder.Entity("VBNET_Core3_project.Models.Pago", b =>
                {
                    b.HasOne("VBNET_Core3_project.Models.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PagosFK");
                });

            modelBuilder.Entity("VBNET_Core3_project.Models.Prestamo", b =>
                {
                    b.HasOne("VBNET_Core3_project.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("PrestamosFK");
                });
#pragma warning restore 612, 618
        }
    }
}
