using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class Review // product-user intersection
    {
        [Required]
        [Key, Column(Order = 1)]
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        [ForeignKey("UserId")]
        public long UserId { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }

        [Required]
        public float Rating { get; set; }

        public string? Comment { get; set; }
    }
}
