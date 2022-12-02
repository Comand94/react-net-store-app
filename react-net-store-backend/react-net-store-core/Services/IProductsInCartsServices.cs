using react_net_store_core.DTO;
using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IProductsInCartsServices
    {
        List<ProductInCartDTO> GetProductsInCarts();
        List<ProductInCartDTO> GetProductsInCartByCart(CartDTO cart);
        ProductInCartDTO GetProductInCartByIds(long cartId, long productId);
        ProductInCartDTO AddProductInCart(ProductInCart productInCart);
        ProductInCartDTO UpdateProductInCart(ProductInCartDTO productInCart);
        void DeleteProductInCart(ProductInCartDTO productInCart);

    }
}
