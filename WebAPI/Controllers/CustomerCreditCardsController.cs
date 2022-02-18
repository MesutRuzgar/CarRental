using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditCardsController : ControllerBase
    {
        ICustomerCreditCardService _customerCreditCardService;

        public CustomerCreditCardsController(ICustomerCreditCardService customerCreditCardService)  
        {
            _customerCreditCardService = customerCreditCardService;
        }
        [HttpGet("getcreditcardbycustomerid")]
        public IActionResult GetCreditCardsByCustomerId(int customerId)
        {
            var result = _customerCreditCardService.GetCreditCardsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.SaveCustomerCreditCard(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecreditcard")]
        public IActionResult DeleteCreditCard(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.DeleteCustomerCreditCard(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
