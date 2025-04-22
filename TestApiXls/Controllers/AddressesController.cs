using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressesController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddresses()
        {
            var addresses = _addressRepository.GetAllAddresses();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (addresses.Count() == 0) {
                ModelState.AddModelError("", "No addresses found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            
            return Ok(addresses);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddress(string name)
        {
            var address = _addressRepository.GetAddress(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (address.Count() == 0)
            {
                ModelState.AddModelError("", "Address not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(address);
        }

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
