using react_net_store_database.Classes;
using react_net_store_database;
using react_net_store_core.DTO;
using Microsoft.EntityFrameworkCore;

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
            return _context.Reviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .Select(r => (ReviewDTO)r).ToList();
        }

        public List<ReviewDTO> GetReviewsByProduct(Product product)
        {
            return _context.Reviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .Where(r => r.Product.Id == product.Id)
                .Select(r => (ReviewDTO)r)
                .ToList();
        }

        public ReviewDTO AddReview(Review review)
        {
            _context.Reviews.Add(review);

            // get corresponding product
            var dbProduct = _context.Products
                .First(p => p.Id == review.ProductId);

            // set new average product rating and increment rating count
            dbProduct.Rating =
                (dbProduct.Rating * dbProduct.RatingCount + review.Rating) / (++dbProduct.RatingCount);

            _context.SaveChanges();
            return (ReviewDTO)review;
        }

        public ReviewDTO UpdateReview(ReviewDTO review)
        {
            var dbReview = _context.Reviews
                .Include(r => r.Product)
                .Include(r => r.User)
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

        public ReviewDTO GetReviewByIds(long userId, long productId)
        {
            var dbReview = _context.Reviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .First(r => r.UserId == userId && r.ProductId == productId);
            return (ReviewDTO)dbReview;
        }
    }
}