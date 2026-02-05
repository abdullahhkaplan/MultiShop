using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
     public class DapperContext : DbContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; initial Catalog=MultiShopDiscountDb; integrated Security=true");
        }

        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }

}

