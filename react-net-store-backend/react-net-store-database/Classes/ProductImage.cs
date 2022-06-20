using System.ComponentModel.DataAnnotations;

namespace react_net_store_database.Classes
{
    public class ProductImage
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public byte[]? Image { get; set; }
    }
}
