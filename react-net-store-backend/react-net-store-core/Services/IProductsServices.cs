using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IProductsServices
    {
        List<Product> GetProducts();
        Product GetProductById(long id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}
