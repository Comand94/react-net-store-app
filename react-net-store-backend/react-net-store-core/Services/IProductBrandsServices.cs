using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IProductBrandsServices
    {
        List<ProductBrand> GetProductBrands();
        ProductBrand GetProductBrandById(long id);
        ProductBrand AddProductBrand(ProductBrand productBrand);
        ProductBrand UpdateProductBrand(ProductBrand productBrand);
        void DeleteProductBrand(ProductBrand productBrand);

    }
}
