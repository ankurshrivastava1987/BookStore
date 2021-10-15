using System;
using Microsoft.EntityFrameworkCore;
using JohnBookStore.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Entity.Infrastructure;

#nullable disable

namespace JohnBookStore.Infrastructure.Data
{
    public partial class JohnBookStoreContext : DbContext
    {
        public JohnBookStoreContext()
        {
        }

        public JohnBookStoreContext(DbContextOptions<JohnBookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<StockDetail> StockDetails { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbQuery<AvailableBooks> AvailableBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=DESKTOP-EDQ22OB;Database=JohnBookStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ISBN");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.ContactEmail).HasMaxLength(500);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(500)
                    .HasColumnName("ISBN");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Orders_Books");
            });

            modelBuilder.Entity<StockDetail>(entity =>
            {
                entity.HasKey(e => e.StockId);

                entity.ToTable("StockDetail");

                entity.Property(e => e.StockId).HasColumnName("StockID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StockDetails)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockDetail_Store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Storename).HasMaxLength(50);
            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
