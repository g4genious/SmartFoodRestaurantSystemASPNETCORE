﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class SmartResturantContext : DbContext
    {
        public SmartResturantContext()
        {
        }

        public SmartResturantContext(DbContextOptions<SmartResturantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Ledger> Ledger { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Produce> Produce { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierAccount> SupplierAccount { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-SLUGB16;Database=SmartResturant;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasMaxLength(50);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Service).HasMaxLength(500);

                entity.Property(e => e.Environment).HasMaxLength(50);

                entity.Property(e => e.Food).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Staff).HasMaxLength(50);
            });

            modelBuilder.Entity<Ledger>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DestinationAccount).HasMaxLength(50);
                entity.Property(e => e.Amount).HasColumnName("Amount");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.Date).HasColumnName("Datetime");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("Payment_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.SourceAccount).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.TableNumber).HasColumnName("TableNumber");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.Status).HasColumnType("status");
                entity.Property(e => e.CustomerId).HasColumnType("CustomerId");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Price).HasColumnName("Price");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");
                entity.Property(e => e.SubTotal).HasColumnName("SubTotal");
                entity.Property(e => e.Size).HasColumnName("Size");
                entity.Property(e => e.OrderId).HasColumnName("OrderId");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.HasKey(e => e.Id);
              
                entity.Property(e => e.TableNumber).HasColumnName("TableNumber");
                entity.Property(e => e.TotalAmount).HasColumnName("TotalAmount");
                entity.Property(e => e.Date).HasColumnName("Date");
                entity.Property(e => e.OrderID).HasColumnName("OrderID");
                entity.Property(e => e.Discount).HasColumnName("Discount");
                entity.Property(e => e.ServiceCharges).HasColumnName("ServiceCharges");
                entity.Property(e => e.GrandTotal).HasColumnName("GrandTotal");

            });

            modelBuilder.Entity<Produce>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("date");
                entity.Property(e => e.PhotoUrl).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Category).HasColumnName("Category");

                entity.Property(e => e.PriceFull).HasColumnName("Price_Full");

                entity.Property(e => e.PriceHalf).HasColumnName("Price_Half");

                entity.Property(e => e.PriceMedium).HasColumnName("Price_Medium");
                entity.Property(e => e.TopCategory).HasColumnName("Top_Category");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("Updated_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_Date")
                    .HasColumnType("date");
                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("Expiry_Date")
                    .HasColumnType("date");
                entity.Property(e => e.Details).HasColumnType("details");
                entity.Property(e => e.Payment_Type).HasColumnType("Payment_Type");
                entity.Property(e => e.Quantity).HasColumnType("Quantity");
                entity.Property(e => e.SubTotal).HasColumnType("SubTotal");
                entity.Property(e => e.Stock_Quantity).HasColumnType("Stock_Quantity");
                entity.Property(e => e.Rate).HasColumnType("Rate");
                entity.Property(e => e.Paid_Amount).HasColumnType("Paid_Amount");
                entity.Property(e => e.Total).HasColumnType("Total");
                //entity.Property(e => e.Grand_Total).HasColumnType("Grand_Total");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
                entity.Property(e => e.Unit).HasMaxLength(50);
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
                entity.HasOne(d => d.Supplier)
                  .WithMany(p => p.Product)
                  .HasForeignKey(d => d.SupplierId)
                  .HasConstraintName("FK_Product_Supplier");
            });
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.JoinDate)
                    .HasColumnName("Join_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName).HasColumnName("ProductName");
                entity.Property(e => e.In_Quantity).HasColumnName("In_Quantity");
                entity.Property(e => e.Out_Quantity).HasColumnName("Out_Quantity");
                entity.Property(e => e.stock).HasColumnName("stock");
                entity.HasOne(d => d.Product)
                  .WithMany(p => p.Stock)
                  .HasForeignKey(d => d.ProductId)
                  .HasConstraintName("FK_Product_Stock");


            });
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<SupplierAccount>(entity =>
            {
                entity.ToTable("Supplier_Account");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Debit).HasColumnName("Debit");
                entity.Property(e => e.SupplierName).HasColumnName("SupplierName");
                entity.Property(e => e.Credit).HasColumnName("Credit");
                entity.Property(e => e.Balance).HasColumnName("Balance");
                entity.Property(e => e.Date).HasColumnName("Date");
                entity.Property(e => e.GrandTotal).HasColumnName("GrandTotal");
                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
                entity.HasOne(d => d.Supplier)
                 .WithMany(p => p.SupplierAccount)
                 .HasForeignKey(d => d.SupplierId)
                 .HasConstraintName("FK_Supplier_Account_Supplier");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SmartFoodRestaurantSystem.Models.OrderView> OrderView { get; set; }

        public DbSet<SmartFoodRestaurantSystem.Models.OrderDetailViewDB> OrderDetailViewDB { get; set; }

   
    }
}
