using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba_QVision.Models
{
    public partial class LIBRERIA_QVISIONContext : DbContext
    {
        public LIBRERIA_QVISIONContext()
        {
        }

        public LIBRERIA_QVISIONContext(DbContextOptions<LIBRERIA_QVISIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;User=sa;Password=1234;Database=LIBRERIA_QVISION");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor);

                entity.ToTable("AUTORES");

                entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasKey(e => e.IdAutorLibro)
                    .HasName("PK__AUTORES___342D28E21D192828");

                entity.ToTable("AUTORES_HAS_LIBROS");

                entity.Property(e => e.IdAutorLibro).HasColumnName("ID_AUTOR_LIBRO");

                entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

                entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_AUTORES");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK_LIBROS");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PK_EDITORIAL");

                entity.ToTable("EDITORIALES");

                entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("SEDE");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__LIBROS__93FF0A06327E2D75");

                entity.ToTable("LIBROS");

                entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

                entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("N_PAGINAS");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("SINOPSIS");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK_EDITORIALES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
