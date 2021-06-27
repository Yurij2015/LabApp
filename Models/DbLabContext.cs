using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LabApp.Models
{
    public partial class DbLabContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbLabContext()
        {
        }

        public DbLabContext(DbContextOptions<DbLabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDatum> EmployeeData { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\ASP.NET\\LabApp\\LabApp\\DataBase\\LabAppDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandDescription).HasMaxLength(500);

                entity.Property(e => e.BrandName).HasMaxLength(150);

                entity.Property(e => e.Country).HasMaxLength(150);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryDescription).HasMaxLength(250);

                entity.Property(e => e.CategoryTitle).HasMaxLength(150);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.DivisionTitle).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_Employee_Division_Id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Employee_Position_Id");
            });

            modelBuilder.Entity<EmployeeDatum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Education).HasMaxLength(150);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsFixedLength(true);

                entity.Property(e => e.Hobby).HasMaxLength(200);

                entity.Property(e => e.Passport).HasMaxLength(11);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeData)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeData_Employee_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Order_Product_Id");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionDesc).HasMaxLength(300);

                entity.Property(e => e.PositionTitle).HasMaxLength(150);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductDesctipton).HasMaxLength(250);

                entity.Property(e => e.ProductName).HasMaxLength(80);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Product_Brand_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category_Id");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.LinkImage)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductImages_Product_Id");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewContent).HasMaxLength(250);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Reviews_Customer_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Reviews_Product_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
