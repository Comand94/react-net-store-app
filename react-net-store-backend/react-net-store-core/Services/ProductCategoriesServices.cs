using react_net_store_database.Classes;
using react_net_store_database;

namespace react_net_store_core.Services
{
    public class ProductCategoriesServices : IProductCategoriesServices
    {
        private AppDbContext _context;

        public ProductCategoriesServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _context.ProductCategories.ToList();
        }

        public ProductCategory GetProductCategoryById(long id)
        {
            return _context.ProductCategories.First(p => p.Id == id);
        }

        public ProductCategory AddProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
            return productCategory;
        }

        public ProductCategory UpdateProductCategory(ProductCategory productCategory)
        {
            var dbProductCategory = _context.ProductCategories.First(p => p.Id == productCategory.Id);
            
            dbProductCategory.Name = productCategory.Name;
            dbProductCategory.Description = productCategory.Description;
            //dbProductCategory.Id = productCategory.Id;
            
            _context.SaveChanges();

            return dbProductCategory;
        }

        public void DeleteProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
        }
    }
}