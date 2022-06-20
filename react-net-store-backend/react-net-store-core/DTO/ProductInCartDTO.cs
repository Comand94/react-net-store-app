using react_net_store_database.Classes;

namespace react_net_store_core.DTO
{
    // PIC Data Transfer Object to avoid sending user sensitive data to Frontend
    public class ProductInCartDTO
    {
        public Product Product { get; set; }

        public CartDTO Cart { get; set; }

        public int Quantity { get; set; } = 1;

        public ProductInCartDTO(ProductInCart pic)
        {
            Product = pic.Product;
            Cart = (CartDTO)pic.Cart;
            Quantity = pic.Quantity;
        }

        // type conversion from PIC into PIC DTO
        public static explicit operator ProductInCartDTO(ProductInCart pic) => new ProductInCartDTO(pic);
    }
}
