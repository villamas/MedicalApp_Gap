using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models
{
    public partial class MedicalAppointmentContext : DbContext
    {
        public MedicalAppointmentContext()
        {
        }

        public MedicalAppointmentContext(DbContextOptions<MedicalAppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<TipoCitas> TipoCitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseSqlServer("data source=DESKTOP-GBGCF7U,52219\\SQLEXPRESS;initial catalog=MedicalAppointment;Persist Security Info=False;User ID=JPVM;Password=123");


                //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MedicalApi.API/appsettings.json").Build();
                //var builder = new DbContextOptionsBuilder<MedicalAppointmentContext>();
                //var connectionString = configuration.GetConnectionString("DatabaseConnection");
                //builder.UseSqlServer(connectionString);
                //return new ApplicationDbContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.IdCita);

                entity.Property(e => e.IdCita)
                    .HasColumnName("Id_cita")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                   .IsRequired()
                   .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdPaciente)
                    .IsRequired()
                    .HasColumnName("id_Paciente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoCita)
                    .HasColumnName("id_tipo_cita")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.NombreMedico)
                    .HasColumnName("Nombre_Medico")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Citas_Paciente");

                entity.HasOne(d => d.IdTipoCitaNavigation)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.IdTipoCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Citas_Tipo_cita");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.Property(e => e.IdPaciente)
                    .HasColumnName("Id_Paciente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FecNacimiento)
                    .HasColumnName("Fec_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_Apellido")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TipoCitas>(entity =>
            {
                entity.HasKey(e => e.IdTipoCita);

                entity.ToTable("Tipo_Citas");

                entity.Property(e => e.IdTipoCita)
                    .HasColumnName("id_Tipo_Cita")
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
