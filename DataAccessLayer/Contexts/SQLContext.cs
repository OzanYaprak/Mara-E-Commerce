﻿using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOne(a => a.ParentCategory).WithMany(a => a.SubCategories).HasForeignKey(a => a.ParentID);
            modelBuilder.Entity<Product>().HasOne(a=>a.Brand).WithMany(a=>a.Products).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ProductCategory>().HasKey(a=> new {a.ProductID, a.CategoryID}); //ProductCategory Tablosunun İki Adet Primary Key'i Bulunuyor.

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID=1,
                AdminName="Ozan",
                AdminSurname="Yaprak",
                AdminEmail="oznyprk@gmail.com",
                AdminUsername="ozanyaprak",
                AdminPassword= "2924785586fd270bac04bfed3f4a6657",
                AdminPhoneNumber="5392129984",
                ActiveStatus= true
            });
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
    }
}
