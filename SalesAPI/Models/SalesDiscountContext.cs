using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Sockets;

namespace SalesAPI.Models
{
    public class SalesDiscountContext : DbContext
    {

        public DbSet<SalesDiscount> SalesDiscountSet { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\mssqllocaldb;Database=SalesDiscount;Trusted_Connection=True");
        }


    }
}
