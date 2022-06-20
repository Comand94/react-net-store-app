using react_net_store_core.DTO;
using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface ICartsServices
    {
        List<CartDTO> GetCarts();
        CartDTO GetCartById(long id);
        CartDTO AddCart(Cart cart);
        CartDTO UpdateCart(CartDTO cart);
        void DeleteCart(CartDTO cart);
    }
}
