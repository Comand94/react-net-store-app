using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_database.Classes;

namespace react_net_store_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AddressesController : ControllerBase
    {
        private IAddressesServices _addressesServices;

        public AddressesController(IAddressesServices addressesServices) 
        {
            _addressesServices = addressesServices;
        }

        [HttpGet]
        public IActionResult GetAddresses() 
        {
            return Ok(_addressesServices.GetAddresses());
        }

        [HttpGet]
        public IActionResult GetAddressById(long id)
        {
            return Ok(_addressesServices.GetAddressById(id));
        }        

        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
                var newAddress = _addressesServices.AddAddress(address);
                return CreatedAtRoute("AddAddress", new {newAddress.Id}, address);
        }

        [HttpPut]
        public IActionResult UpdateAddress(Address address)
        { 
            return Ok(_addressesServices.UpdateAddress(address));
        }

        [HttpDelete]
        public IActionResult DeleteAddress(Address address)
        { 
            _addressesServices.DeleteAddress(address);
            return Ok();
        }
    }
}