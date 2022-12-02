using react_net_store_database.Classes;
using react_net_store_database;
using Microsoft.EntityFrameworkCore;

namespace react_net_store_core.Services
{
    public class ProductsServices : IProductsServices
    {
        private AppDbContext _context;

        public ProductsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .ToList();
        }

        public Product GetProductById(long id)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .First(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var dbProduct = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Image)
                .Include(p => p.Brand)
                .First(p => p.Id == product.Id);
            
            //dbProduct.Id = product.Id;
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Category = product.Category;
            dbProduct.Image = product.Image;
            dbProduct.Brand = product.Brand;
            dbProduct.Stock = product.Stock;
            dbProduct.Rating = product.Rating;

            _context.SaveChanges();

            return dbProduct;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}