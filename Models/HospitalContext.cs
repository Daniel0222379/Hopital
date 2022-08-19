

using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Models{
    public class HospitalContext : DbContext{
        public HospitalContext(DbContextOptions<HospitalContext> option): base(option){

        }
        public DbSet<Medico> Medico{get;set;}
        public DbSet<Paciente> Paciente{get;set;}
        public DbSet<Medicamento> Medicamento { get; set; }

        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<AtencionMedico> AtencionMedico { get; set; }

        public DbSet<Atencion> Atencion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Medico>(entity =>{
                entity.ToTable("Medico");

                entity.HasKey(model => model.IdMedico);

                entity.Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(a => a.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                  entity.Property(a => a.Cedula)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            });
            modelBuilder.Entity<Paciente>(entity =>{
                entity.ToTable("Paciente");

                entity.HasKey(model => model.IdPaciente);


                entity.Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(a => a.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                  entity.Property(a => a.Cedula)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(a => a.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            });

             modelBuilder.Entity<Medicamento>(entity =>{
                entity.ToTable("Medicamento");

                entity.HasKey(model => model.IdMedicamento);


                entity.Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(a => a.Codigo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                  entity.Property(a => a.Observacion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);


            });

            modelBuilder.Entity<Especialidad>(entity =>{
                entity.ToTable("Especialidad");
        
                
                entity.HasKey(model => model.IdEspecialidad);


                entity.Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });
                
                
             modelBuilder.Entity<Atencion>(entity =>{
                entity.ToTable("Atencion");

                entity.HasKey(model => model.IdAtencion);


                entity.Property(a => a.Hora)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                 entity.Property(a => a.Fecha)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                 entity.Property(a => a.Categoria)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);



            });

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasKey(e => new{e.IdEspecialidad,e.IdMedico});
                

            modelBuilder.Entity<MedicoEspecialidad>()
            .HasOne(e => e.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicoEspecialidad>()
            .HasOne(e => e.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad)
            .OnDelete(DeleteBehavior.Cascade);

            
            

            modelBuilder.Entity<AtencionMedico> ()
                .HasKey(e => new{e.IdAtencion,e.IdMedico});

            modelBuilder.Entity<AtencionMedico>().HasOne(e => e.Atencion)
            .WithMany(p => p.AtencionMedico)
            .HasForeignKey(p => p.IdAtencion);

            modelBuilder.Entity<AtencionMedico>().HasOne(e => e.Medico)
            .WithMany(p => p.AtencionMedico)
            .HasForeignKey(p => p.IdMedico);

        }

    }
}