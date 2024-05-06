using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCcitas.Models;

public partial class CitasContext : DbContext
{
    public CitasContext()
    {
    }

    public CitasContext(DbContextOptions<CitasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=PAPISANTI\\PAPISANTI; database=Citas; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Citas__814F3126AA7FC067");

            entity.Property(e => e.IdCita)
                .ValueGeneratedNever()
                .HasColumnName("idCita");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fechaHora");
            entity.Property(e => e.IdIdentificacionMed).HasColumnName("idIdentificacionMed");
            entity.Property(e => e.IdIdentificacionUs).HasColumnName("idIdentificacionUs");
            entity.Property(e => e.Ips)
                .HasMaxLength(50)
                .HasColumnName("ips");
            entity.Property(e => e.NroConsultorio).HasColumnName("nroConsultorio");

            entity.HasOne(d => d.IdIdentificacionMedNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdIdentificacionMed)
                .HasConstraintName("FK__Citas__idIdentif__4E88ABD4");

            entity.HasOne(d => d.IdIdentificacionUsNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdIdentificacionUs)
                .HasConstraintName("FK__Citas__idIdentif__4D94879B");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdIdentificacionMed).HasName("PK__Medicos__19D531E92DC35ED4");

            entity.Property(e => e.IdIdentificacionMed)
                .ValueGeneratedNever()
                .HasColumnName("idIdentificacionMed");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdIdentificacion).HasName("PK__Usuarios__E911EE4216424B0A");

            entity.Property(e => e.IdIdentificacion)
                .ValueGeneratedNever()
                .HasColumnName("idIdentificacion");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(20)
                .HasColumnName("nombres");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
