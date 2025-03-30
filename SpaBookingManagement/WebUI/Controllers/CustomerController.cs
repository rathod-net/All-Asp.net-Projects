using BusinessLayer.Impletations;
using BusinessLayer.Interfaces;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
           public CustomerController(ICustomerServices customerServices)
           {
            _customerServices = customerServices;
           }

        [HttpGet]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerServices.GetAll();
            return Ok(customer);
           
        }

        [HttpPost]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [ProducesResponseType(201,Type =typeof(CustomerDto))]
        public async Task<IActionResult> Create([FromBody] CustomerDto customer)
        {
            if(customer != null)
            {
               await _customerServices.Add(customer);
                return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
       // [Route("api/Customer/id")]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerServices.GetById(id);
            return Ok(customer);
        }


    }
}
