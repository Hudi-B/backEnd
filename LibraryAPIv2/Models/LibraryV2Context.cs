using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LibraryAPIv2.Models;

public partial class LibraryV2Context : DbContext
{
    public LibraryV2Context()
    {
    }

    public LibraryV2Context(DbContextOptions<LibraryV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.56.1;database=LibraryV2;user=root;password=password;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_hungarian_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Author");

            entity.HasIndex(e => e.NationalityId, "nationality_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Authors)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("Author_ibfk_1");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Book");

            entity.HasIndex(e => e.AuthorId, "author_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Genre)
                .HasMaxLength(30)
                .HasColumnName("genre");
            entity.Property(e => e.Pubdate).HasColumnName("pubdate");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("Book_ibfk_1");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Nationality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nation)
                .HasMaxLength(30)
                .HasColumnName("nation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
