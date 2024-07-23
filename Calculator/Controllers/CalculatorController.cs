using Calculator.CustomException;
using Calculator.BI.Interfaces;
using Calculator.BI.Helpers;
using Calculator.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public IActionResult Sum([FromQuery] double firstTerm, [FromQuery] double secondTerm)
        {
            try
            {
                var answer = _calculateService.CalculateSum(firstTerm, secondTerm);

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
                if (DataHelper.CheckDivisionByZero(divider))
                     return BadRequest("Вы не можете разделить на 0");

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
        public IActionResult SquareRoot([FromQuery] double initialNumber, [FromQuery] double rootDegree)
        {
            try
            {
                if(DataHelper.CheackNumberLessThanZeroInRoot(initialNumber, rootDegree))
                {
                    return BadRequest("Число под корнем не может быть меньше 0, при чётном оснавании корня");
                }

                var answer = _calculateService.CalculateSquareRoot(initialNumber, rootDegree);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Expression([FromQuery] string expression)
        {
            try
            {
                if(string.IsNullOrEmpty(expression))
                {
                    return BadRequest("Пустое выражение");
                }

                var answer = _calculateService.CalculateExpression(expression);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
