using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApiEntregable2.Data.Entities;

namespace WebApiEntregable2.Data;

public partial class TaskManagerDbContext : DbContext
{
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ETask> ETasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ETask>(entity =>
        {
            entity.ToTable("Tasks");
            entity.HasKey(e => e.Id).HasName("PK_Tasks_Id");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAtUtc).HasDefaultValueSql("(sysutcdatetime())", "DF_Tasks_CreatedAtUtc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
