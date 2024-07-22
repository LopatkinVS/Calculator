using Calculator.BI.Interfaces;
using Calculator.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class CalculatorController : BaseApiController
    {
        private readonly ICalculateService _calculateService;

        public CalculatorController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Sum([FromQuery] double firstTerm, [FromQuery] double seconTerm)
        {
            try
            {
                var answer = _calculateService.CalculateSum(firstTerm, seconTerm);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Substartion([FromQuery] double initialNumber, [FromQuery] double substractionNumber)
        {
            try
            {
                var answer = _calculateService.CalculateSubtraction(initialNumber, substractionNumber);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Multiplication([FromQuery] double firstMultiplier, [FromQuery] double secondMultiplier)
        {
            try
            {
                var answer = _calculateService.CalculateMultiplication(firstMultiplier, secondMultiplier);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Division([FromQuery] double dividend, [FromQuery] double divider)
        {
            try
            {
                var answer = _calculateService.CalculateDivision(dividend, divider);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Pow([FromQuery] double initialNumber, [FromQuery] double power)
        {
            try
            {
                var answer = _calculateService.CalculatePow(initialNumber, power);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult SquareRoot([FromQuery] double initialNumber)
        {
            try
            {
                var answer = _calculateService.CalculateSquareRoot(initialNumber);

                return Ok(answer);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
