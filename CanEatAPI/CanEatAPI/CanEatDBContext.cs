using CanEatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CanEatAPI
{
    public class CanEatDBContext : DbContext
    {
        public DbSet<MsCompany> MsCompany { get; set; }
        public DbSet<MsCart> MsCart { get; set; }
        public DbSet<MsCustomer> MsCustomer { get; set; }
        public DbSet<MsFood> MsFood { get; set; }
        public DbSet<MsShop> MsShop { get; set; }
        public DbSet<TrDetail> TrDetail { get; set; }
        public DbSet<TrHeader> TrHeader { get; set; }
        public CanEatDBContext(DbContextOptions<CanEatDBContext>options) : base(options) 
        { 
            
        }
    }
}
