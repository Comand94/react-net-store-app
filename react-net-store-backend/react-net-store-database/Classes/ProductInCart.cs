using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class ProductInCart // product-cart intersection
    {
        [Required]
        [Key, Column(Order = 1)]
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        [ForeignKey("CartId")]
        public long CartId { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
