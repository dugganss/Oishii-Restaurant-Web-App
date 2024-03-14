using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CO5227_Assignment.wwwroot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CO5227_Assignment.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace CO5227_Assignment.Data
{
    public class CO5227_AssignmentContext : IdentityDbContext
    {
        public CO5227_AssignmentContext (DbContextOptions<CO5227_AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<CO5227_Assignment.wwwroot.Models.MenuItems> MenuItemss { get; set; } = default!;

        public DbSet<CO5227_Assignment.Models.CheckoutCustomer> CheckoutCustomers { get; set; } = default!;
        public DbSet<CO5227_Assignment.Models.Basket> Baskets { get; set; } = default!;
        public DbSet<CO5227_Assignment.Models.BasketItem> BasketItems { get; set; } = default!;
        public DbSet<CO5227_Assignment.Models.OrderHistory> OrderHistories { get; set; } = default!;
        public DbSet<CO5227_Assignment.Models.OrderItem> OrderItems { get; set; } = default!;

        [NotMapped]
        public DbSet<CO5227_Assignment.Models.CheckoutItem> CheckoutItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItems>().ToTable("MenuItems");

            modelBuilder.Entity<BasketItem>().HasKey(t => new {t.StockID, t.BasketID});
            modelBuilder.Entity<OrderItem>().HasKey(vf => new { vf.OrderNo, vf.StockID });
        }
    }
}
