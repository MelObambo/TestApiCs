using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/parcel")]
    [ApiController]
    public class ParcelsController : Controller
    {
        private readonly IParcelRepository _parcelRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Parcel>))]
        public IActionResult GetAllParcels()
        {
            var parcels = _parcelRepository.GetAllParcels();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Parcel>))]
        public IActionResult GetParcel(int parcelNumber)
        {
            var parcels = _parcelRepository.GetParcel(parcelNumber);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (parcels.Count() == 0)
            {
                ModelState.AddModelError("", "Parcel not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(parcels);
        }

        public ParcelsController(IParcelRepository parcelRepository)
        {
            this._parcelRepository = parcelRepository;
        }
    }
}
