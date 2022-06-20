using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public ProductCategory? Category { get; set; }

        [Required]
        [ForeignKey("ImageId")]
        public ProductImage? Image { get; set; }

        [Required]
        [ForeignKey("BrandId")]
        public ProductBrand? Brand { get; set; }

        public int Stock { get; set; } = 0;

        public float Rating { get; set; }

    }
}
