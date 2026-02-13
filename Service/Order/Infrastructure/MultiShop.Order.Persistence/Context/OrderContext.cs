using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        public DbSet<Address> addresses { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Ordering> orderings { get; set; }

    }
}
