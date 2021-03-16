using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private static int _delay = 0;

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequestModel request)
        {
            try
            {
                await Task.Delay(_delay);
                return request.Balance >= request.Price
                    ? Ok(new { Result = true, Balance = request.Balance - request.Price})
                    : Ok(new { Result = false, Balance = request.Balance});
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("delay")]
        public IActionResult SetDelay([FromBody] DelayRequestModel request)
        {
            _delay = request.Delay;
            return NoContent();
        }

    }
}
