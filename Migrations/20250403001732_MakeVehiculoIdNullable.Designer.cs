﻿// <auto-generated />
using System;
using ITMFotomultas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITMFotomultas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250403001732_MakeVehiculoIdNullable")]
    partial class MakeVehiculoIdNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITMFotomultas.Models.Fotomulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Infraccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Fotomultas");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FotomultaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FotomultaId");

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Fotomulta", b =>
                {
                    b.HasOne("ITMFotomultas.Models.Vehiculo", "Vehiculo")
                        .WithMany("Fotomultas")
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Imagen", b =>
                {
                    b.HasOne("ITMFotomultas.Models.Fotomulta", "Fotomulta")
                        .WithMany("Imagenes")
                        .HasForeignKey("FotomultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fotomulta");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Fotomulta", b =>
                {
                    b.Navigation("Imagenes");
                });

            modelBuilder.Entity("ITMFotomultas.Models.Vehiculo", b =>
                {
                    b.Navigation("Fotomultas");
                });
#pragma warning restore 612, 618
        }
    }
}
