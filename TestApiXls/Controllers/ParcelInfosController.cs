using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/parcelinfo")]
    [ApiController]
    public class ParcelInfosController : Controller
    {
        private readonly IParcelInfoRepository _parcelInfoRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ParcelInfo>))]
        public IActionResult GetAllParcelInfos()
        {
            var parcels = _parcelInfoRepository.GetAllParcelInfos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ParcelInfo>))]
        public IActionResult GetParcelInfo(int parcelNumber)
        {
            var parcels = _parcelInfoRepository.GetParcelInfo(parcelNumber);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (parcels.Count() == 0)
            {
                ModelState.AddModelError("", "Parcel not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(parcels);
        }

        public ParcelInfosController(IParcelInfoRepository parcelInfoRepository)
        {
            this._parcelInfoRepository = parcelInfoRepository;
        }
    }
}
