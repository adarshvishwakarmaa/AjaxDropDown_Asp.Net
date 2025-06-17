using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AjaxDropDown.Models;

public partial class DropdownContext : DbContext
{
    public DropdownContext()
    {
    }

    public DropdownContext(DbContextOptions<DropdownContext> options)
        : base(options)
    {
    }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistId).HasName("pk_distId");

            entity.ToTable("districts");

            entity.Property(e => e.DistId).HasColumnName("distId");
            entity.Property(e => e.DisName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("disName");
            entity.Property(e => e.StateId).HasColumnName("stateId");

            entity.HasOne(d => d.State).WithMany(p => p.Districts)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("fk_stateId");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("pk_stateId");

            entity.ToTable("states");

            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("stateName");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkId).HasName("pk_workId");

            entity.ToTable("Worker");

            entity.Property(e => e.WorkId).HasColumnName("workId");
            entity.Property(e => e.DistId).HasColumnName("distId");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.WorkDob).HasColumnName("workDob");
            entity.Property(e => e.WorkName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("workName");

            entity.HasOne(d => d.Dist).WithMany(p => p.Workers)
                .HasForeignKey(d => d.DistId)
                .HasConstraintName("fk_distId");

            entity.HasOne(d => d.State).WithMany(p => p.Workers)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("fk_stateId1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
