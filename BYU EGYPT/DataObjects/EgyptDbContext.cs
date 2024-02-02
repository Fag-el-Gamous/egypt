using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BYU_EGYPT.DataObjects;

public partial class EgyptDbContext : DbContext
{
    public EgyptDbContext()
    {
    }

    public EgyptDbContext(DbContextOptions<EgyptDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<C14> C14s { get; set; }

    public virtual DbSet<TestTable> TestTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:byu-egypt-db-server.database.windows.net,1433;Initial Catalog=BYU_Egypt_DB;Persist Security Info=False;User ID=byu-egypt-db-server-login;Password=rQC8%&wAyD5ig4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<C14>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("C14");

            entity.Property(e => e.AgeBp).HasColumnName("AgeBP");
            entity.Property(e => e.C14id).HasColumnName("C14ID");
            entity.Property(e => e.C14sampleNum2017).HasColumnName("C14SampleNum2017");
            entity.Property(e => e.Contents)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Labs)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocationDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Other)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResearchQuestions).HasColumnType("text");
        });

        modelBuilder.Entity<TestTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestTabl__3214EC2766B35550");

            entity.ToTable("TestTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
