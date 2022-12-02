using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices) 
        {
            _productsServices = productsServices;
        }

        [HttpGet]
        public IActionResult GetProducts() 
        {
            return Ok(_productsServices.GetProducts());
        }

        [HttpGet(Name = "GetProductById")]
        public IActionResult GetProductById(long id)
        {
            return Ok(_productsServices.GetProductById(id));
        }        

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
                var newProduct = _productsServices.AddProduct(product);
                return CreatedAtRoute("GetProductById", new {id = newProduct.Id}, newProduct);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        { 
            return Ok(_productsServices.UpdateProduct(product));
        }

        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        { 
            _productsServices.DeleteProduct(product);
            return Ok();
        }
    }
}