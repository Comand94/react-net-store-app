using react_net_store_database.Classes;

namespace react_net_store_core.DTO
{
    // Cart Data Transfer Object to avoid sending user sensitive data to Frontend
    public class CartDTO 
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Address? Address { get; set; }

        public float TotalPrice { get; set; } = 0f;

        public bool WasPaidFor { get; set; } = false;

        public bool WasDelivered { get; set; } = false;

        public DateTime TimeOfPurchase { get; set; }

        public CartDTO(Cart c) 
        {
            Id = c.Id;
            if (c.User != null)
            {
                Username = c.User.Username;
                Email = c.User.Email;
            }
            Address = c.Address;
            TotalPrice = c.TotalPrice;
            WasPaidFor = c.WasPaidFor;
            WasDelivered = c.WasDelivered;
            TimeOfPurchase = c.TimeOfPurchase;
        }

        // type conversion from Cart into CartDTO
        public static explicit operator CartDTO(Cart c) => new CartDTO(c);
    }
}
