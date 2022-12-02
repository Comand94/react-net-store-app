using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoriesServices _productCategoriesServices;

        public ProductCategoriesController(IProductCategoriesServices productCategoriesServices) 
        {
            _productCategoriesServices = productCategoriesServices;
        }

        [HttpGet]
        public IActionResult GetProductCategories() 
        {
            return Ok(_productCategoriesServices.GetProductCategories());
        }

        [HttpGet(Name = "GetProductCategoryById")]
        public IActionResult GetProductCategoryById(long id)
        {
            return Ok(_productCategoriesServices.GetProductCategoryById(id));
        }        

        [HttpPost]
        public IActionResult AddProductCategory(ProductCategory productCategory)
        {
                var newProductCategory = _productCategoriesServices.AddProductCategory(productCategory);
                return CreatedAtRoute("GetProductCategoryById", new {id = newProductCategory.Id}, newProductCategory);
        }

        [HttpPut]
        public IActionResult UpdateProductCategory(ProductCategory productCategory)
        { 
            return Ok(_productCategoriesServices.UpdateProductCategory(productCategory));
        }

        [HttpDelete]
        public IActionResult DeleteProductCategory(ProductCategory productCategory)
        { 
            _productCategoriesServices.DeleteProductCategory(productCategory);
            return Ok();
        }
    }
}