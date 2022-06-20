using react_net_store_database.Classes;
using react_net_store_database;

namespace react_net_store_core.Services
{
    public class AddressesServices : IAddressesServices
    {
        private AppDbContext _context;

        public AddressesServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }

        public Address GetAddressById(long id)
        {
            return _context.Addresses.First(p => p.Id == id);
        }

        public Address AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            var dbAddress = _context.Addresses.First(p => p.Id == address.Id);
            
            dbAddress.FirstName = address.FirstName;
            dbAddress.LastName = address.LastName;
            dbAddress.Email = address.Email;
            dbAddress.Phone = address.Phone;
            dbAddress.City = address.City;
            dbAddress.Postcode = address.Postcode;
            dbAddress.StreetAndApartment = address.StreetAndApartment;
            
            _context.SaveChanges();

            return dbAddress;
        }

        public void DeleteAddress(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}