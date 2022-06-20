using react_net_store_database.Classes;
using react_net_store_database;
using react_net_store_core.DTO;

namespace react_net_store_core.Services
{
    public class ProductsInCartsServices : IProductsInCartsServices
    {
        private AppDbContext _context;

        public ProductsInCartsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductInCartDTO> GetProductsInCarts()
        {
            return _context.ProductsInCarts
                .Select(pic => (ProductInCartDTO)pic)
                .ToList();
        }

        public List<ProductInCartDTO> GetProductsInCartByCart(CartDTO cart)
        {
            return _context.ProductsInCarts
                .Where(p => p.Cart.Id == cart.Id)
                .Select(pic => (ProductInCartDTO)pic)
                .ToList();
        }

        public ProductInCartDTO AddProductInCart(ProductInCart productInCart)
        {
            _context.ProductsInCarts.Add(productInCart);
            _context.SaveChanges();
            return (ProductInCartDTO)productInCart;
        }

        public ProductInCartDTO UpdateProductInCart(ProductInCartDTO productInCart)
        {
            var dbProductInCart = 
                _context.ProductsInCarts
                .First(p => p.Product.Id == productInCart.Product.Id && p.Cart.Id == productInCart.Cart.Id);

            dbProductInCart.Product = productInCart.Product;
            //dbProductInCart.Cart = productInCart.Cart;
            dbProductInCart.Quantity = productInCart.Quantity;

            _context.SaveChanges();
            return productInCart;
        }

        public void DeleteProductInCart(ProductInCartDTO productInCart)
        {
            var dbProductInCart = 
                _context.ProductsInCarts
                .First(p => p.Product.Id == productInCart.Product.Id && p.Cart.Id == productInCart.Cart.Id);
            _context.ProductsInCarts.Remove(dbProductInCart);
            _context.SaveChanges();
        }
    }
}