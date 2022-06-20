using react_net_store_database.Classes;
using react_net_store_database;

namespace react_net_store_core.Services
{
    public class ProductImagesServices : IProductImagesServices
    {
        private AppDbContext _context;

        public ProductImagesServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductImage> GetProductImages()
        {
            return _context.ProductImages.ToList();
        }

        public ProductImage GetProductImageById(long id)
        {
            return _context.ProductImages.First(p => p.Id == id);
        }

        public ProductImage AddProductImage(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();
            return productImage;
        }

        public ProductImage UpdateProductImage(ProductImage productImage)
        {
            var dbProductImage = _context.ProductImages.First(p => p.Id == productImage.Id);

            dbProductImage.Image = productImage.Image;
            //dbProductImage.Id = productImage.Id;
            
            _context.SaveChanges();

            return dbProductImage;
        }

        public void DeleteProductImage(ProductImage productImage)
        {
            _context.ProductImages.Remove(productImage);
            _context.SaveChanges();
        }
    }
}