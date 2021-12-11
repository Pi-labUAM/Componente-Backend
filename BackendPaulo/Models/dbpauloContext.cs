using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class dbpauloContext : DbContext
    {
        public dbpauloContext()
        {
        }

        public dbpauloContext(DbContextOptions<dbpauloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Research> Researches { get; set; }
        public virtual DbSet<Talk> Talks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JHMVABP7;Database=dbpaulo; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Inscription>(entity =>
            {
                entity.HasKey(e => new { e.Research, e.Participant, e.CreateDate })
                    .HasName("PK__Inscript__23E5F2D067E3F7B9");

                entity.ToTable("Inscription");

                entity.Property(e => e.Research)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("research");

                entity.Property(e => e.Participant)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("participant");

                entity.Property(e => e.CreateDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("create_date");

                entity.HasOne(d => d.ParticipantNavigation)
                    .WithMany(p => p.Inscriptions)
                    .HasForeignKey(d => d.Participant)
                    .HasConstraintName("FK__Inscripti__parti__403A8C7D");

                entity.HasOne(d => d.ResearchNavigation)
                    .WithMany(p => p.Inscriptions)
                    .HasForeignKey(d => d.Research)
                    .HasConstraintName("FK__Inscripti__resea__3F466844");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.Document)
                    .HasName("PK__Particip__1D810B13893A7944");

                entity.ToTable("Participant");

                entity.HasIndex(e => e.Email, "UQ__Particip__AB6E61640C0E6EF5")
                    .IsUnique();

                entity.Property(e => e.Document)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("document");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("picture");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.CreateDate)
                    .HasName("PK__Publicat__9C1CA257E8814173");

                entity.ToTable("Publication");

                entity.Property(e => e.CreateDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("create_date");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.PublicationDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("publication_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Research>(entity =>
            {
                entity.HasKey(e => e.CreateDate)
                    .HasName("PK__Research__9C1CA257FD067398");

                entity.ToTable("Research");

                entity.Property(e => e.CreateDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("create_date");

                entity.Property(e => e.Abstract)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("abstract");

                entity.Property(e => e.Bibliography)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("bibliography");

                entity.Property(e => e.Objectives)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("objectives");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.Results)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("results");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Talk>(entity =>
            {
                entity.HasKey(e => e.CreateDate)
                    .HasName("PK__Talks__9C1CA2576481518E");

                entity.Property(e => e.CreateDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("create_date");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.Property(e => e.Speaker)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("speaker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
