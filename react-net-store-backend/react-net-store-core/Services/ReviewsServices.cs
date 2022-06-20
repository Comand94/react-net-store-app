using react_net_store_database.Classes;
using react_net_store_database;
using react_net_store_core.DTO;

namespace react_net_store_core.Services
{
    public class ReviewsServices : IReviewsServices
    {
        private AppDbContext _context;

        public ReviewsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<ReviewDTO> GetReviews()
        {
            return _context.Reviews.Select(r => (ReviewDTO)r).ToList();
        }

        public List<ReviewDTO> GetReviewsByProduct(Product product)
        {
            return _context.Reviews
                .Where(r => r.Product.Id == product.Id)
                .Select(r => (ReviewDTO)r)
                .ToList();
        }

        public ReviewDTO AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return (ReviewDTO)review;
        }

        public ReviewDTO UpdateReview(ReviewDTO review)
        {
            var dbReview = _context.Reviews
                .First(r => r.User.Username == review.Username && r.Product.Id == review.Product.Id);
            
            dbReview.Product = review.Product;
            //dbReview.User = review.User;
            dbReview.Rating = review.Rating;
            dbReview.Comment = review.Comment;
            
            _context.SaveChanges();

            return review;
        }

        public void DeleteReview(ReviewDTO review)
        {
            var dbReview = 
                _context.Reviews
                .First(r => r.Product.Id == review.Product.Id && r.User.Username == review.Username);
            _context.Remove(dbReview);
            _context.SaveChanges();
        }
    }
}