using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class SistemaCampeonatoContext : DbContext
    {
        public SistemaCampeonatoContext()
        {
        }

        public SistemaCampeonatoContext(DbContextOptions<SistemaCampeonatoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arbitro> Arbitro { get; set; } = null!;
        public virtual DbSet<Campeonato> Campeonato { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<DetallePArtido> DetallePArtido { get; set; } = null!;
        public virtual DbSet<Equipo> Equipo { get; set; } = null!;
        public virtual DbSet<Estadio> Estadio { get; set; } = null!;
        public virtual DbSet<Fixture> Fixture { get; set; } = null!;
        public virtual DbSet<InscripcionesCampeonato> InscripcionesCampeonato { get; set; } = null!;
        public virtual DbSet<Jugador> Jugador { get; set; } = null!;
        public virtual DbSet<Partido> Partido { get; set; } = null!;
        public virtual DbSet<Persona> Persona { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.16.248.33; Database=SistemaCampeonato; User=sistema; Password=scz; TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arbitro>(entity =>
            {
                entity.Property(e => e.certificaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.partidoNavigation)
                    .WithMany(p => p.Arbitro)
                    .HasForeignKey(d => d.partido)
                    .HasConstraintName("fk_partido");

                entity.HasOne(d => d.persona)
                    .WithMany(p => p.Arbitro)
                    .HasForeignKey(d => d.personaId)
                    .HasConstraintName("fk_personaArbitro");
            });

            modelBuilder.Entity<Campeonato>(entity =>
            {
                entity.Property(e => e.descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fechaFin).HasColumnType("date");

                entity.Property(e => e.fechaInicio).HasColumnType("date");

                entity.Property(e => e.nombreCampeonato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.organizador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.reglas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.categoria)
                    .WithMany(p => p.Campeonato)
                    .HasForeignKey(d => d.categoriaId)
                    .HasConstraintName("fk_categoria");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePArtido>(entity =>
            {
                entity.HasKey(e => e.detallePArtido_id)
                    .HasName("PK__DetalleP__10B333C1D71400AE");

                entity.Property(e => e.observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.equipo)
                    .WithMany(p => p.DetallePArtido)
                    .HasForeignKey(d => d.equipoId)
                    .HasConstraintName("fk_equipodetalle");

                entity.HasOne(d => d.partido)
                    .WithMany(p => p.DetallePArtido)
                    .HasForeignKey(d => d.partidoId)
                    .HasConstraintName("fk_partidodetalle");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.equipo_id)
                    .HasName("PK__Equipo__50EAD2BFA05B3110");

                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.representantes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.HasKey(e => e.estadio_id)
                    .HasName("PK__Estadio__097C37851591FF1F");

                entity.Property(e => e.descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fixture>(entity =>
            {
                entity.HasKey(e => e.fixture_id)
                    .HasName("PK__Fixture__1CF1559238C8B03A");

                entity.Property(e => e.cancha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.equipos_participantes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.hora).HasColumnType("date");

                entity.HasOne(d => d.estadio)
                    .WithMany(p => p.Fixture)
                    .HasForeignKey(d => d.estadioId)
                    .HasConstraintName("fk_estadofix");

                entity.HasOne(d => d.partido)
                    .WithMany(p => p.Fixture)
                    .HasForeignKey(d => d.partidoId)
                    .HasConstraintName("fk_partidofix");
            });

            modelBuilder.Entity<InscripcionesCampeonato>(entity =>
            {
                entity.HasKey(e => e.inscripciones_id)
                    .HasName("PK__Inscripc__ECD9EF0E883E356B");

                entity.HasOne(d => d.campeonato)
                    .WithMany(p => p.InscripcionesCampeonato)
                    .HasForeignKey(d => d.campeonatoId)
                    .HasConstraintName("fk_campeonato");

                entity.HasOne(d => d.equipo)
                    .WithMany(p => p.InscripcionesCampeonato)
                    .HasForeignKey(d => d.equipoId)
                    .HasConstraintName("fk_equipo");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.Property(e => e.altura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.estadisticas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.habilidades)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.lesiones)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.equipo)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.equipoId)
                    .HasConstraintName("fk_equipojugador");

                entity.HasOne(d => d.persona)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.personaId)
                    .HasConstraintName("fk_persona");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.partido_id)
                    .HasName("PK__Partido__7227A516CF6F373A");

                entity.Property(e => e.arbitro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.equipoLocal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.equipoVisitante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fecha).HasColumnType("date");

                entity.Property(e => e.observaciones)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.reglas_especificas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.resultado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.estadio)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.estadioId)
                    .HasConstraintName("fk_estadioPartido");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.persona_id)
                    .HasName("PK__Persona__189F813A4FF1ABA5");

                entity.Property(e => e.apellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.apellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
