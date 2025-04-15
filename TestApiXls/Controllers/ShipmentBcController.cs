using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/shipmentBc")]
    [ApiController]
    public class ShipmentBcController : ControllerBase
    {

        [HttpGet]
        ShipmentBc[] GetShipmentBcs(StdShipmentRequest request)
        {
            return res;
        }

        [HttpGet("{id}")]
        ShipmentBc GetShipmentBc(StdShipmentRequest request)
        {
            return res;
        }


        [HttpPost]
        public ShipmentBc[] createShipmentBc(
            int customer_countrycode,
            int customer_centernumber,
            int customer_number,
            Address receiveraddress,
            AddressInfo receiverInfo,
            Address shipperAdress,
            AddressInfo shipperInfo,
            Address retourAddress,
            /*StdServices services,*/
            String weight,
            String shippingdate,
            String referencenumber,
            String reference2,
            String reference3,
            String reference4
            )
        {}

    }

    [Route("api/shipmentWithLabelBc")]
    [ApiController]
    public class ShipmentBcController : ControllerBase
    {

        [HttpGet]
        ShipmentBc[] GetShipmentBcs(StdShipmentRequest request)
        {
            return res;
        }

        [HttpGet("{id}")]
        ShipmentBc GetShipmentBc(StdShipmentRequest request)
        {
            return res;
        }


        [HttpPost]
        public ShipmentBc[] createShipmentBc(
            int customer_countrycode,
            int customer_centernumber,
            int customer_number,
            Address receiveraddress,
            AddressInfo receiverInfo,
            Address shipperAdress,
            AddressInfo shipperInfo,
            Address retourAddress,
            /*StdServices services,*/
            String weight,
            String shippingdate,
            String referencenumber,
            String reference2,
            String reference3,
            String reference4
            )
        { }

    }
}
