using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;

namespace TestApiXls.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.Address>))]
        public IActionResult GetAddresses()
        {
            var addresses = _addressRepository.GetAddresses();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(addresses);
            // return View(addresses);
        }

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
