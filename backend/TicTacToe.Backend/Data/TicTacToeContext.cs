using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Entities;

namespace TicTacToe.Backend.Data;

public partial class TicTacToeContext : DbContext
{
    public TicTacToeContext()
    {
    }

    public TicTacToeContext(DbContextOptions<TicTacToeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Result> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("results_pkey");

            entity.ToTable("results");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Winner)
                .HasMaxLength(1)
                .HasColumnName("winner");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
