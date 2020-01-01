using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartFoodRestaurantSystem.Models
{
    public partial class SmartFoodResturantContext : DbContext
    {
        public SmartFoodResturantContext()
        {
        }

        public SmartFoodResturantContext(DbContextOptions<SmartFoodResturantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<MenuAdd> MenuAdd { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMenu> OrderMenu { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<StaffRegistration> StaffRegistration { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SupplierRegistration> SupplierRegistration { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-SLUGB16;Database=SmartFoodResturant;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerRegistration>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customer_Registration");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("Customer_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasColumnName("Customer_Phone_Number")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TableId).HasColumnName("Table_ID");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.CustomerRegistration)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Customer_Registration_Order_Table");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.FeedBackId).HasColumnName("FeedBack_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.FeedBackDescription)
                    .HasColumnName("FeedBack_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.FeedBackEnvironment)
                    .HasColumnName("FeedBack_Environment")
                    .HasMaxLength(50);

                entity.Property(e => e.FeedBackStaffBehaviour)
                    .HasColumnName("FeedBack_Staff_Behaviour")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_FeedBack_Customer_Registration");
            });

            modelBuilder.Entity<MenuAdd>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Menu_Add");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.MenuCreatedBy)
                    .HasColumnName("Menu_Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuCreatedDate)
                    .HasColumnName("Menu_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MenuDescription)
                    .HasColumnName("Menu_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuName)
                    .HasColumnName("Menu_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuPriceFull).HasColumnName("Menu_Price_Full");

                entity.Property(e => e.MenuPriceHalf).HasColumnName("Menu_Price_Half");

                entity.Property(e => e.MenuStatus)
                    .HasColumnName("Menu_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuUpdatedBy)
                    .HasColumnName("Menu_Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuUpdatedDate)
                    .HasColumnName("Menu_Updated_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.MenuAdd)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Menu_Add_Admin");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.TableId).HasColumnName("Table_ID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_Order_Order_Menu");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Order_Table");
            });

            modelBuilder.Entity<OrderMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Order_Menu");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.MenuDescription)
                    .HasColumnName("Menu_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuName)
                    .HasColumnName("Menu_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuPriceFull).HasColumnName("Menu_Price_Full");

                entity.Property(e => e.MenuPriceHalf).HasColumnName("Menu_Price_Half");

                entity.Property(e => e.MenuQuantity).HasColumnName("Menu_Quantity");

                entity.Property(e => e.TableId).HasColumnName("Table_ID");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.OrderMenu)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Order_Menu_Order_Table");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.ToTable("Order_Table");

                entity.Property(e => e.TableId).HasColumnName("Table_ID");

                entity.Property(e => e.TableNumber).HasColumnName("Table_Number");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Payment_Supplier_Registration");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");

                entity.Property(e => e.ProductReceivedBy)
                    .HasColumnName("Product_Received_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductReceivedDate)
                    .HasColumnName("Product_Received_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductReturnBy)
                    .HasColumnName("Product_Return_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductReturnDate)
                    .HasColumnName("Product_Return_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductUpdatedBy)
                    .HasColumnName("Product_Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductUpdatedDate)
                    .HasColumnName("Product_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Product_Supplier_Registration");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductRemain).HasColumnName("Product_Remain");

                entity.Property(e => e.ProductSoldOut).HasColumnName("Product_Sold_Out");

                entity.Property(e => e.SaleReportCreatedBy)
                    .HasColumnName("Sale_Report_Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.SaleReportCreatedDate)
                    .HasColumnName("Sale_Report_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleReportModifiedBy)
                    .HasColumnName("Sale_Report_Modified_By")
                    .HasMaxLength(50);

                entity.Property(e => e.SaleReportModifiedDate)
                    .HasColumnName("Sale_Report_Modified_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Sale_Admin");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Sale_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Sale_Product");
            });

            modelBuilder.Entity<StaffRegistration>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.ToTable("Staff_Registration");

                entity.Property(e => e.StaffId).HasColumnName("Staff_ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.StaffAddress)
                    .HasColumnName("Staff_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffCnic)
                    .HasColumnName("Staff_CNIC")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StaffJobEndDate)
                    .HasColumnName("Staff_Job_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffJobStartDate)
                    .HasColumnName("Staff_Job_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffName)
                    .HasColumnName("Staff_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffPhoneNumber)
                    .HasColumnName("Staff_Phone_Number")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.StaffRole)
                    .HasColumnName("Staff_Role")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffShiftTime).HasColumnName("Staff_Shift_Time");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.StaffRegistration)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Staff_Registration_Admin");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).HasColumnName("Stock_ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.CurrentStock).HasColumnName("Current_Stock");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductType)
                    .HasColumnName("Product_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.StockAddedBy)
                    .HasColumnName("Stock_Added_By")
                    .HasMaxLength(50);

                entity.Property(e => e.StockAddedDate)
                    .HasColumnName("Stock_Added_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StockModifiedBy)
                    .HasColumnName("Stock_Modified_By")
                    .HasMaxLength(50);

                entity.Property(e => e.StockModifiedDate)
                    .HasColumnName("Stock_Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.TotalAmount).HasColumnName("Total_Amount");

                entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Admin");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Stock_Product");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Stock_Supplier_Registration");
            });

            modelBuilder.Entity<SupplierRegistration>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("Supplier_Registration");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.SupplierCompany)
                    .HasColumnName("Supplier_Company")
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierName)
                    .HasColumnName("Supplier_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierPhoneNumber)
                    .HasColumnName("Supplier_Phone_Number")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.SupplierRegistration)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Supplier_Registration_Admin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
