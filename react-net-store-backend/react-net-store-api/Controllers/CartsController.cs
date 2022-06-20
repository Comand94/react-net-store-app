using Microsoft.AspNetCore.Mvc;
using react_net_store_core.DTO;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartsController : ControllerBase
    {
        private ICartsServices _cartsServices;

        public CartsController(ICartsServices cartsServices) 
        {
            _cartsServices = cartsServices;
        }

        [HttpGet]
        public IActionResult GetCarts() 
        {
            return Ok(_cartsServices.GetCarts());
        }

        [HttpGet]
        public IActionResult GetCartById(long id)
        {
            return Ok(_cartsServices.GetCartById(id));
        }        

        [HttpPost]
        public IActionResult AddCart(Cart cart)
        {
                var newCart = _cartsServices.AddCart(cart);
                return CreatedAtRoute("AddCart", new {newCart.Id}, newCart);
        }

        [HttpPut]
        public IActionResult UpdateCart(CartDTO cart)
        { 
            return Ok(_cartsServices.UpdateCart(cart));
        }

        [HttpDelete]
        public IActionResult DeleteCart(CartDTO cart)
        { 
            _cartsServices.DeleteCart(cart);
            return Ok();
        }
    }
}