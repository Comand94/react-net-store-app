using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IProductImagesServices
    {
        List<ProductImage> GetProductImages();
        ProductImage GetProductImageById(long id);
        ProductImage AddProductImage(ProductImage productImage);
        ProductImage UpdateProductImage(ProductImage productImage);
        void DeleteProductImage(ProductImage productImage);

    }
}
