using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; } 
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");
            modelBuilder.Entity<OrderDetail>().Property(or => or.Id).HasColumnName("OrderID");
            modelBuilder.Entity<OrderDetail>().Property(or => or.ProductId).HasColumnName("ProductID");
            modelBuilder.Entity<OrderDetail>().Property(or => or.PiecePrice).HasColumnName("UnitPrice");
            modelBuilder.Entity<OrderDetail>().Property(or => or.Amount).HasColumnName("Quantity");
            modelBuilder.Entity<OrderDetail>().Property(or => or.Discount).HasColumnName("Discount");

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().Property(o => o.ShipperId).HasColumnName("ShipVia");

            modelBuilder.Entity<Shipper>().ToTable("Shippers");
            modelBuilder.Entity<Shipper>().Property(s => s.ShipCompanyName).HasColumnName("CompanyName");
            modelBuilder.Entity<Shipper>().Property(s => s.ShipCompanyPhone).HasColumnName("Phone");

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerCity).HasColumnName("City");

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeFirsName).HasColumnName("FirstName");
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeLastName).HasColumnName("LastName");
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeCity).HasColumnName("City");

            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supplier>().Property(s => s.SupplierId).HasColumnName("SupplierID");
            modelBuilder.Entity<Supplier>().Property(s => s.SupplierCompanyName).HasColumnName("CompanyName");
            modelBuilder.Entity<Supplier>().Property(s => s.SupplierContactName).HasColumnName("ContactName");
            modelBuilder.Entity<Supplier>().Property(s => s.SupplierCity).HasColumnName("City");

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().Property(ct => ct.CategoryDescription).HasColumnName("Description");

            modelBuilder.Entity<EmployeeTerritory>().ToTable("EmployeeTerritories");
            modelBuilder.Entity<EmployeeTerritory>(et => et.HasNoKey());

        }
    }
}
