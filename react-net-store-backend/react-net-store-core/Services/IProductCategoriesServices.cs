using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IProductCategoriesServices
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryById(long id);
        ProductCategory AddProductCategory(ProductCategory productCategory);
        ProductCategory UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(ProductCategory productCategory);

    }
}
