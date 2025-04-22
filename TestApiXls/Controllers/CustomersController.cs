using Microsoft.AspNetCore.Mvc;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            if (customers.Count() == 0)
            {
                ModelState.AddModelError("", "No Customers found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }

            return Ok(customers);
        }

        [HttpGet("{number}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomer(int number)
        {
            var customer = _customerRepository.GetCustomer(number);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (customer.Count() == 0)
            {
                ModelState.AddModelError("", "Customer not found");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        public IActionResult CreateCustomer([FromQuery] int countryCode,[FromQuery] int centerNumber)
        {
            var customerExists = _customerRepository.GetCustomer(countryCode, centerNumber).FirstOrDefault();

            if (customerExists != null) 
            {
                ModelState.AddModelError("", "Customer already exists");
                return StatusCode(StatusCodes.Status409Conflict, ModelState);
            }

            if (!_customerRepository.CreateCustomer(countryCode, centerNumber)) {
                ModelState.AddModelError("", "An error occured");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            

            return CreatedAtAction(nameof(GetCustomer), new { number = _customerRepository.getNumber() }, _customerRepository.GetCustomer(countryCode, centerNumber).FirstOrDefault());
        }

        public CustomersController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
    }
}
