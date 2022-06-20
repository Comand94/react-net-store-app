using react_net_store_database.Classes;
using react_net_store_database;
using react_net_store_core.DTO;

namespace react_net_store_core.Services
{
    public class CartsServices : ICartsServices
    {
        private AppDbContext _context;

        public CartsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<CartDTO> GetCarts()
        {
            return _context.Carts
                .Select(c => (CartDTO)c)
                .ToList();
        }

        public CartDTO GetCartById(long id)
        {
            return (CartDTO)_context.Carts.First(p => p.Id == id);
        }

        public CartDTO AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return (CartDTO)cart;
        }

        public CartDTO UpdateCart(CartDTO cart)
        {
            var dbCart = _context.Carts.First(p => p.Id == cart.Id);

            //dbCart.Id = cart.Id;
            //dbCart.User = cart.User;
            dbCart.Address = cart.Address;
            dbCart.TotalPrice = cart.TotalPrice;
            dbCart.WasPaidFor = cart.WasPaidFor;
            dbCart.WasDelivered = cart.WasDelivered;
            dbCart.TimeOfPurchase = cart.TimeOfPurchase;
            
            _context.SaveChanges();

            return cart;
        }

        public void DeleteCart(CartDTO cart)
        {
            var dbCart = _context.Carts.First(c => c.Id == cart.Id);
            _context.Remove(dbCart);
            _context.SaveChanges();
        }
    }
}