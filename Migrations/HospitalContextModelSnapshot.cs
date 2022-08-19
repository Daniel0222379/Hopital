﻿// <auto-generated />
using System;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital.Models.Atencion", b =>
                {
                    b.Property<int>("IdAtencion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria")
                        .HasColumnType("int")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("NombreMedicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePaciente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAtencion");

                    b.ToTable("Atencion");
                });

            modelBuilder.Entity("Hospital.Models.AtencionMedico", b =>
                {
                    b.Property<int>("IdAtencion")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.HasKey("IdAtencion", "IdMedico");

                    b.HasIndex("IdMedico");

                    b.ToTable("AtencionMedico");
                });

            modelBuilder.Entity("Hospital.Models.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Hospital.Models.Medicamento", b =>
                {
                    b.Property<int>("IdMedicamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdMedicamento");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("Hospital.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdMedico");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Hospital.Models.MedicoEspecialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.HasKey("IdEspecialidad", "IdMedico");

                    b.HasIndex("IdMedico");

                    b.ToTable("MedicoEspecialidad");
                });

            modelBuilder.Entity("Hospital.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Hospital.Models.AtencionMedico", b =>
                {
                    b.HasOne("Hospital.Models.Atencion", "Atencion")
                        .WithMany("AtencionMedico")
                        .HasForeignKey("IdAtencion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Medico", "Medico")
                        .WithMany("AtencionMedico")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital.Models.MedicoEspecialidad", b =>
                {
                    b.HasOne("Hospital.Models.Especialidad", "Especialidad")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Medico", "Medico")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
