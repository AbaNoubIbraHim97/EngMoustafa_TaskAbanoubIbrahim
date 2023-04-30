using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Product.Infrastrucre.Context
{
    public class ProductDbContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProductDbContext(IConfiguration configuration) => Configuration = configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Product.Domain.Models.Product> Product { get; set; }






    }
}
