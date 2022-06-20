using System.ComponentModel.DataAnnotations;

namespace react_net_store_database.Classes
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string StreetAndApartment { get; set; }
    }
}
