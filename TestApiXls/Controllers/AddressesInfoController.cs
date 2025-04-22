using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/addressInfo")]
    [ApiController]
    public class AddressesInfoController : Controller
    {
        private readonly IAddressInfoRepository _addressInfoRepository;

        [HttpGet("{addressName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AddressInfo>))]
        public IActionResult GetAddressInfo(string addressName)
        {
            var addressInfo = _addressInfoRepository.GetAddressInfo(addressName).FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (addressInfo == null)
            {
                ModelState.AddModelError("", "Address not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(addressInfo);
        }

        public AddressesInfoController(IAddressInfoRepository addressInfoRepository)
        {
            this._addressInfoRepository = addressInfoRepository;
        }
    }
}
