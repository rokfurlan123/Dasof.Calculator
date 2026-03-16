using Dasof.Calculator.Business.Common;
using Dasof.Calculator.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dasof.Calculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private ICalculatorRepository _calculatorRepository;

        public CalculatorController(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> Calculate([FromBody] RequestModel request)
        {
            try
            {
                var result = await _calculatorRepository.CalculateTotalVehiclePrice(request);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There has been a server error");
            }
        }
    }
}
