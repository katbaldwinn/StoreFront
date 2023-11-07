using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Candle.DATA.EF.Models
{
	public partial class CandlesContext : DbContext
	{
		public CandlesContext()
		{
		}

		public CandlesContext(DbContextOptions<CandlesContext> options)
		    : base(options)
		{
		}

		public virtual DbSet<Category> Categories { get; set; } = null!;
		public virtual DbSet<Order> Orders { get; set; } = null!;
		public virtual DbSet<Product> Products { get; set; } = null!;
		public virtual DbSet<ProductOrder> ProductOrders { get; set; } = null!;
		public virtual DbSet<StockStatus> StockStatuses { get; set; } = null!;
		public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Candles;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>(entity =>
			{
				entity.Property(e => e.CategoryDescription)
				 .HasMaxLength(50)
				 .IsUnicode(false);

				entity.Property(e => e.CategoryName)
				 .HasMaxLength(50)
				 .IsUnicode(false);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.Property(e => e.OrderPlaced).HasColumnType("datetime");

				entity.Property(e => e.UserId).HasMaxLength(128);

				entity.HasOne(d => d.User)
				 .WithMany(p => p.Orders)
				 .HasForeignKey(d => d.UserId)
				 .OnDelete(DeleteBehavior.ClientSetNull)
				 .HasConstraintName("FK_Orders_UserDetails");
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.Property(e => e.ProductDescription)
				 .HasMaxLength(1000)
				 .IsUnicode(false);

				entity.Property(e => e.ProductImage)
				 .HasMaxLength(75)
				 .IsUnicode(false);

				entity.Property(e => e.ProductName)
				 .HasMaxLength(500)
				 .IsUnicode(false);

				entity.Property(e => e.ProductPrice).HasColumnType("money");

				entity.HasOne(d => d.Category)
				 .WithMany(p => p.Products)
				 .HasForeignKey(d => d.CategoryId)
				 .OnDelete(DeleteBehavior.ClientSetNull)
				 .HasConstraintName("FK_Products_category");

				entity.HasOne(d => d.Status)
				 .WithMany(p => p.Products)
				 .HasForeignKey(d => d.StatusId)
				 .OnDelete(DeleteBehavior.ClientSetNull)
				 .HasConstraintName("FK_Products_StockStatus");
			});

			modelBuilder.Entity<ProductOrder>(entity =>
			{
				entity.Property(e => e.PurchasePrice).HasColumnType("money");

				entity.HasOne(d => d.Order)
				 .WithMany(p => p.ProductOrders)
				 .HasForeignKey(d => d.OrderId)
				 .OnDelete(DeleteBehavior.ClientSetNull)
				 .HasConstraintName("FK_ProductOrders_Orders");

				entity.HasOne(d => d.Product)
				 .WithMany(p => p.ProductOrders)
				 .HasForeignKey(d => d.ProductId)
				 .OnDelete(DeleteBehavior.ClientSetNull)
				 .HasConstraintName("FK_ProductOrders_Products");
			});

			modelBuilder.Entity<StockStatus>(entity =>
			{
				entity.HasKey(e => e.StatusId);

				entity.ToTable("StockStatus");

				entity.Property(e => e.StatusName)
				 .HasMaxLength(12)
				 .IsUnicode(false);
			});

			modelBuilder.Entity<UserDetail>(entity =>
			{
				entity.HasKey(e => e.UserId);

				entity.Property(e => e.UserId).HasMaxLength(128);

				entity.Property(e => e.Address)
				 .HasMaxLength(100)
				 .IsUnicode(false);

				entity.Property(e => e.City)
				 .HasMaxLength(50)
				 .IsUnicode(false);

				entity.Property(e => e.State)
				 .HasMaxLength(2)
				 .IsUnicode(false)
				 .IsFixedLength();

				entity.Property(e => e.UserName)
				 .HasMaxLength(100)
				 .IsUnicode(false);

				entity.Property(e => e.Zip)
				 .HasMaxLength(5)
				 .IsUnicode(false)
				 .IsFixedLength();

				entity.Property(e => e.Phone)
				.IsUnicode(true)
				.HasMaxLength(24);

				entity.Property(e => e.Email)
				.IsUnicode(true)
				.HasMaxLength(50);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
