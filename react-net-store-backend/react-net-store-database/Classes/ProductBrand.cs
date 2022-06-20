using System.ComponentModel.DataAnnotations;

namespace react_net_store_database.Classes
{
    public class ProductBrand
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
