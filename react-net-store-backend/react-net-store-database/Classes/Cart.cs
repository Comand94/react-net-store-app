using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class Cart // or a finalized cart, AKA sale
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("AddressId")]
        public Address? Address { get; set; }

        public float TotalPrice { get; set; } = 0f;

        public bool WasPaidFor { get; set; } = false;

        public bool WasDelivered { get; set; } = false;

        public DateTime TimeOfPurchase { get; set; }
    }
}
