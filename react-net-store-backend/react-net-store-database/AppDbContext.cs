using Microsoft.EntityFrameworkCore;
using react_net_store_database.Classes;

namespace react_net_store_database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductInCart> ProductsInCarts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Admin> Admins { get; set; }

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=React-Net-Store-Database;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>().HasKey(table => new {
                table.ProductId,
                table.UserId
            });

            builder.Entity<ProductInCart>().HasKey(table => new {
                table.ProductId,
                table.CartId
            });
        }
    }
}
