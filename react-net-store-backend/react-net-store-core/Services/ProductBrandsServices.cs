using react_net_store_database.Classes;
using react_net_store_database;

namespace react_net_store_core.Services
{
    public class ProductBrandsServices : IProductBrandsServices
    {
        private AppDbContext _context;

        public ProductBrandsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductBrand> GetProductBrands()
        {
            return _context.ProductBrands.ToList();
        }

        public ProductBrand GetProductBrandById(long id)
        {
            return _context.ProductBrands.First(p => p.Id == id);
        }

        public ProductBrand AddProductBrand(ProductBrand productBrand)
        {
            _context.ProductBrands.Add(productBrand);
            _context.SaveChanges();
            return productBrand;
        }

        public ProductBrand UpdateProductBrand(ProductBrand productBrand)
        {
            var dbProductBrand = _context.ProductBrands.First(p => p.Id == productBrand.Id);

            //dbProductBrand.Id = productBrand.Id;
            dbProductBrand.Name = productBrand.Name;

            _context.SaveChanges();

            return dbProductBrand;
        }

        public void DeleteProductBrand(ProductBrand productBrand)
        {
            _context.ProductBrands.Remove(productBrand);
            _context.SaveChanges();
        }
    }
}