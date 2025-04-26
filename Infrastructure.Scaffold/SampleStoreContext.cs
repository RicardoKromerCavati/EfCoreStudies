using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Scaffold;

public partial class SampleStoreContext : DbContext
{
    public SampleStoreContext()
    {
    }

    public SampleStoreContext(DbContextOptions<SampleStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookTable> BookTables { get; set; }

    public virtual DbSet<CustomerTable> CustomerTables { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-50RVRKA;Database=SampleStore;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookTable>(entity =>
        {
            entity.ToTable("BookTable");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Publisher)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerTable>(entity =>
        {
            entity.ToTable("CustomerTable");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.ToTable("OrderTable");

            entity.HasIndex(e => e.BookId, "IX_OrderTable_BookId");

            entity.HasIndex(e => e.CustomerId, "IX_OrderTable_CustomerId");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderTables).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderTables).HasForeignKey(d => d.CustomerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
