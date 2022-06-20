using react_net_store_core.DTO;
using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IReviewsServices
    {
        List<ReviewDTO> GetReviews();
        List<ReviewDTO> GetReviewsByProduct(Product product);
        ReviewDTO AddReview(Review review);
        ReviewDTO UpdateReview(ReviewDTO review);
        void DeleteReview(ReviewDTO review);

    }
}
