using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/parcelinfosin")]
    [ApiController]
    public class ParcelInfoSinsController : Controller
    {
        private readonly IParcelInfoSinRepository _parcelInfoSinRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ParcelInfoSin>))]
        public IActionResult GetAllParcelInfoSins()
        {
            var parcels = _parcelInfoSinRepository.GetAllParcelInfoSins();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (parcels.Count() == 0)
            {
                ModelState.AddModelError("", "No Parcels found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(parcels);
        }

        [HttpGet("{parcelNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ParcelInfoSin>))]
        public IActionResult GetParcelInfoSin(int parcelNumber)
        {
            var parcels = _parcelInfoSinRepository.GetParcelInfoSin(parcelNumber);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (parcels.Count() == 0)
            {
                ModelState.AddModelError("", "Parcel not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(parcels);
        }

        public ParcelInfoSinsController(IParcelInfoSinRepository parcelInfoSinRepository)
        {
            this._parcelInfoSinRepository = parcelInfoSinRepository;
        }
    }
}