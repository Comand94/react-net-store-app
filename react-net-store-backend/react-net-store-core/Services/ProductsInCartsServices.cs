using react_net_store_database.Classes;
using react_net_store_database;
using react_net_store_core.DTO;
using Microsoft.EntityFrameworkCore;

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
                .Include(pic => pic.Product)
                .Include(pic => pic.Cart)
                .Select(pic => (ProductInCartDTO)pic)
                .ToList();
        }

        public List<ProductInCartDTO> GetProductsInCartByCart(CartDTO cart)
        {
            return _context.ProductsInCarts
                .Include(pic => pic.Product)
                .Include(pic => pic.Cart)
                .Where(p => p.Cart.Id == cart.Id)
                .Select(pic => (ProductInCartDTO)pic)
                .ToList();
        }

        public ProductInCartDTO AddProductInCart(ProductInCart productInCart)
        {
            _context.ProductsInCarts.Add(productInCart);

            // increase cart total price
            var dbCart = _context.Carts
                .First(c => c.Id == productInCart.Cart.Id);
            dbCart.TotalPrice += productInCart.Product.Price * productInCart.Quantity;

            _context.SaveChanges();
            return (ProductInCartDTO)productInCart;
        }

        public ProductInCartDTO UpdateProductInCart(ProductInCartDTO productInCart)
        {
            var dbProductInCart = 
                _context.ProductsInCarts
                .Include(pic => pic.Product)
                .Include(pic => pic.Cart)
                .First(p => p.Product.Id == productInCart.Product.Id && p.Cart.Id == productInCart.Cart.Id);

            dbProductInCart.Product = productInCart.Product; // price might've changed, among other things
            //dbProductInCart.Cart = productInCart.Cart;
            
            // Quantity changed - probably the most common use case
            if (dbProductInCart.Quantity != productInCart.Quantity)
            {
                // decrease cart total price by old quantity and price of this product
                // increase cart total price by new quantity of this product
                var dbCart = _context.Carts.First(c => c.Id == productInCart.Cart.Id);
                dbCart.TotalPrice -= dbProductInCart.Product.Price * dbProductInCart.Quantity;
                dbCart.TotalPrice += productInCart.Product.Price * productInCart.Quantity;

                // update quantity
                dbProductInCart.Quantity = productInCart.Quantity;
            }

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

        public ProductInCartDTO GetProductInCartByIds(long cartId, long productId)
        {
            var dbProductInCart = _context.ProductsInCarts
                .Include(pic => pic.Product)
                .Include(pic => pic.Cart)
                .First(p => p.Cart.Id == cartId && p.Product.Id == productId);
            return (ProductInCartDTO)dbProductInCart;
        }
    }
}