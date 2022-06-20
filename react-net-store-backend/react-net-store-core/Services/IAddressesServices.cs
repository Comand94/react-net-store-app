using react_net_store_database.Classes;

namespace react_net_store_core.Services
{
    public interface IAddressesServices
    {
        List<Address> GetAddresses();
        Address GetAddressById(long id);
        Address AddAddress(Address address);
        Address UpdateAddress(Address address);
        void DeleteAddress(Address address);

    }
}
