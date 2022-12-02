using Microsoft.AspNetCore.Mvc;
using react_net_store_core.DTO;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsInCartsController : ControllerBase
    {
        private IProductsInCartsServices _productsInCartsServices;

        public ProductsInCartsController(IProductsInCartsServices productsInCartsServices) 
        {
            _productsInCartsServices = productsInCartsServices;
        }

        [HttpGet]
        public IActionResult GetProductsInCarts() 
        {
            return Ok(_productsInCartsServices.GetProductsInCarts());
        }

        [HttpGet]
        public IActionResult GetProductsInCartByCart(CartDTO cart)
        {
            return Ok(_productsInCartsServices.GetProductsInCartByCart(cart));
        }

        [HttpGet(Name = "GetProductsInCartByIds")]
        public IActionResult GetProductsInCartByIds(long cartId, long productId)
        {
            return Ok(_productsInCartsServices.GetProductInCartByIds(cartId, productId));
        }

        [HttpPost]
        public IActionResult AddProductInCart(ProductInCart productInCart)
        {
                var newProductInCart = _productsInCartsServices.AddProductInCart(productInCart);
                var productId = newProductInCart.Product.Id;
                var cartId = newProductInCart.Cart.Id;
                return CreatedAtRoute("GetProductsInCartByIds", new {cartId, productId }, newProductInCart);
        }

        [HttpPut]
        public IActionResult UpdateProductInCart(ProductInCartDTO productInCart)
        { 
            return Ok(_productsInCartsServices.UpdateProductInCart(productInCart));
        }

        [HttpDelete]
        public IActionResult DeleteProductInCart(ProductInCartDTO productInCart)
        { 
            _productsInCartsServices.DeleteProductInCart(productInCart);
            return Ok();
        }
    }
}