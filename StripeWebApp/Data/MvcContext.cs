using Microsoft.EntityFrameworkCore;
using StripeWebApp.Models;

namespace StripeWebApp.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }
    }
}
