using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductBrandsController : ControllerBase
    {
        private IProductBrandsServices _productBrandsServices;

        public ProductBrandsController(IProductBrandsServices productBrandsServices) 
        {
            _productBrandsServices = productBrandsServices;
        }

        [HttpGet]
        public IActionResult GetProductBrands() 
        {
            return Ok(_productBrandsServices.GetProductBrands());
        }

        [HttpGet(Name = "GetProductBrandById")]
        public IActionResult GetProductBrandById(long id)
        {
            return Ok(_productBrandsServices.GetProductBrandById(id));
        }        

        [HttpPost]
        public IActionResult AddProductBrand(ProductBrand productBrand)
        {
                var newProductBrand = _productBrandsServices.AddProductBrand(productBrand);
                return CreatedAtRoute("GetProductBrandById", new {id = newProductBrand.Id}, newProductBrand);
        }

        [HttpPut]
        public IActionResult UpdateProductBrand(ProductBrand productBrand)
        { 
            return Ok(_productBrandsServices.UpdateProductBrand(productBrand));
        }

        [HttpDelete]
        public IActionResult DeleteProductBrand(ProductBrand productBrand)
        {
            _productBrandsServices.DeleteProductBrand(productBrand);
            return Ok();
        }
    }
}