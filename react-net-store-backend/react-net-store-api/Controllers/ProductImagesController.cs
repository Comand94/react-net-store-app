using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductImagesController : ControllerBase
    {
        private IProductImagesServices _productImagesServices;

        public ProductImagesController(IProductImagesServices productImagesServices) 
        {
            _productImagesServices = productImagesServices;
        }

        [HttpGet]
        public IActionResult GetProductImages() 
        {
            return Ok(_productImagesServices.GetProductImages());
        }

        [HttpGet(Name = "GetProductImageById")]
        public IActionResult GetProductImageById(long id)
        {
            return Ok(_productImagesServices.GetProductImageById(id));
        }        

        [HttpPost]
        public IActionResult AddProductImage(ProductImage productImage)
        {
                var newProductImage = _productImagesServices.AddProductImage(productImage);
                return CreatedAtRoute("GetProductImageById", new {id = newProductImage.Id}, newProductImage);
        }

        [HttpPut]
        public IActionResult UpdateProductImage(ProductImage productImage)
        { 
            return Ok(_productImagesServices.UpdateProductImage(productImage));
        }

        [HttpDelete]
        public IActionResult DeleteProductImage(ProductImage productImage)
        { 
            _productImagesServices.DeleteProductImage(productImage);
            return Ok();
        }
    }
}