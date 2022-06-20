using react_net_store_database.Classes;

namespace react_net_store_core.DTO
{
    // Review Data Transfer Object to avoid sending user sensitive data to Frontend
    public class ReviewDTO
    {
        public Product Product { get; set; }

        public string Username { get; set; }

        public float Rating { get; set; }

        public string? Comment { get; set; }

        public ReviewDTO(Review r)
        {
            Product = r.Product;
            Username = r.User.Username;
            Rating = r.Rating;
            Comment = r.Comment;
        }

        // type conversion from Review into ReviewDTO
        public static explicit operator ReviewDTO(Review r) => new ReviewDTO(r);
    }
}
