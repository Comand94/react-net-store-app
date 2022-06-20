using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? ExternalId { get; set; }

        public string? ExternalType { get; set; }

        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
    }
}
