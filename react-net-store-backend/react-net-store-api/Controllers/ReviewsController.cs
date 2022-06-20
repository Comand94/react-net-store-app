using Microsoft.AspNetCore.Mvc;
using react_net_store_core.DTO;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReviewsController : ControllerBase
    {
        private IReviewsServices _reviewsServices;

        public ReviewsController(IReviewsServices reviewsServices) 
        {
            _reviewsServices = reviewsServices;
        }

        [HttpGet]
        public IActionResult GetReviews() 
        {
            return Ok(_reviewsServices.GetReviews());
        }

        [HttpGet]
        public IActionResult GetReviewsByProduct(Product product)
        {
            return Ok(_reviewsServices.GetReviewsByProduct(product));
        }        

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
                var newReview = _reviewsServices.AddReview(review);
                var productId = newReview.Product.Id;
                var userId = newReview.Username;
                return CreatedAtRoute("AddReview", new {productId, userId }, newReview);
        }

        [HttpPut]
        public IActionResult UpdateReview(ReviewDTO review)
        { 
            return Ok(_reviewsServices.UpdateReview(review));
        }

        [HttpDelete]
        public IActionResult DeleteReview(ReviewDTO review)
        { 
            _reviewsServices.DeleteReview(review);
            return Ok();
        }
    }
}