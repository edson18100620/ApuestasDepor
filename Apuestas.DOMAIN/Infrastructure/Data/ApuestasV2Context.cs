using System;
using System.Collections.Generic;
using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApuestasDepor.DOMAIN.Infrastructure.Data
{
    public partial class ApuestasV2Context : DbContext
    {
        public ApuestasV2Context()
        {
        }

        public ApuestasV2Context(DbContextOptions<ApuestasV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Apuesta> Apuesta { get; set; } = null!;
        public virtual DbSet<AudioVisual> AudioVisual { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Equipos> Equipos { get; set; } = null!;
        public virtual DbSet<ModalidadPago> ModalidadPago { get; set; } = null!;
        public virtual DbSet<Pais> Pais { get; set; } = null!;
        public virtual DbSet<Partido> Partido { get; set; } = null!;
        public virtual DbSet<Problemas> Problemas { get; set; } = null!;
        public virtual DbSet<Promocion> Promocion { get; set; } = null!;
        public virtual DbSet<Rol> Rol { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;
        //public virtual DbSet<UsuarioRol> UsuarioRol { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=desktop-g4alvpb\\sqlexpress02;Database=ApuestasV2;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apuesta>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FechaApuesta).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.EquipoId)
                    .HasConstraintName("FK_Apuesta_Equipos");

                entity.HasOne(d => d.Modalidad)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.ModalidadId)
                    .HasConstraintName("FK_Apuesta_ModalidadPago");

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.PartidoId)
                    .HasConstraintName("FK_Apuesta_Partido");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Apuesta_Usuario");
            });

            modelBuilder.Entity<AudioVisual>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK_Equipos_Pais");
            });

            modelBuilder.Entity<ModalidadPago>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CuotaLoc).HasColumnName("Cuota_Loc");

                entity.Property(e => e.CuotaVis).HasColumnName("Cuota_Vis");

                entity.Property(e => e.EquipoLocId).HasColumnName("Equipo_Loc_Id");

                entity.Property(e => e.EquipoVisId).HasColumnName("Equipo_Vis_Id");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Partido_Categoria");

                entity.HasOne(d => d.EquipoLoc)
                    .WithMany(p => p.PartidoEquipoLoc)
                    .HasForeignKey(d => d.EquipoLocId)
                    .HasConstraintName("FK_Partido_Equipos");

                entity.HasOne(d => d.EquipoVis)
                    .WithMany(p => p.PartidoEquipoVis)
                    .HasForeignKey(d => d.EquipoVisId)
                    .HasConstraintName("FK_Partido_Equipos1");
            });

            modelBuilder.Entity<Problemas>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.CodAudioVisualNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodAudioVisual)
                    .HasConstraintName("FK_Problemas_AudioVisual");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("FK_Problemas_Usuario");
            });

            modelBuilder.Entity<Promocion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detalle)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaIni).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.CodAudioVisualNavigation)
                    .WithMany(p => p.Promocion)
                    .HasForeignKey(d => d.CodAudioVisual)
                    .HasConstraintName("FK_Promocion_AudioVisual");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Promocion)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("FK_Promocion_Usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK_Usuario_Pais");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Usuario_Rol");                
            });

            //modelBuilder.Entity<UsuarioRol>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasOne(d => d.Rol)
            //        .WithMany(p => p.UsuarioRol)
            //        .HasForeignKey(d => d.RolId)
            //        .HasConstraintName("FK_UsuarioRol_Rol");

            //    entity.HasOne(d => d.Usuario)
            //        .WithMany(p => p.UsuarioRol)
            //        .HasForeignKey(d => d.UsuarioId)
            //        .HasConstraintName("FK_UsuarioRol_Usuario");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
