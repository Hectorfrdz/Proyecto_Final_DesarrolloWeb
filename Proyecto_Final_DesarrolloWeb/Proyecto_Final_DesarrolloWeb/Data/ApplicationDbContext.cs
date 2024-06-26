﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DesarrolloWeb.Models;

namespace Proyecto_Final_DesarrolloWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<OrderItems> Orderitems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product_Categories> Product_Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
    }

}
