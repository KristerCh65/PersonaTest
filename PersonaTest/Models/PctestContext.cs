using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonaTest.Models;

public partial class PctestContext : DbContext
{
    public PctestContext()
    {
    }

    public PctestContext(DbContextOptions<PctestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Identidad).HasName("PK__Persona__5BFE4D84CE9F4FE6");

            entity.ToTable("Persona");

            entity.Property(e => e.Identidad)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("identidad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
