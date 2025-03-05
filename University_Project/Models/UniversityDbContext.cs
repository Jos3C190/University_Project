using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace University_Project.Models;

public partial class UniversityDbContext : DbContext
{
    public UniversityDbContext() { }

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options) { }

    public virtual DbSet<Career> Careers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.CareerId).HasName("PK__careers__A4D2D7F7BFEE7216");

            entity.ToTable("careers");

            entity.Property(e => e.CareerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Edited).HasColumnType("datetime");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
