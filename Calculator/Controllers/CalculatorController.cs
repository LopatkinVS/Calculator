using Calculator.CustomException;
using Calculator.BI.Interfaces;
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
        public IActionResult Sum([FromQuery] string firstTerm, [FromQuery] string secondTerm)
        {
            try
            {
                if (!double.TryParse(firstTerm, out double firstTermValue) || !double.TryParse(secondTerm, out double secondTermValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                var answer = _calculateService.CalculateSum(firstTermValue, secondTermValue);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Substartion([FromQuery] string initialNumber, [FromQuery] string substractionNumber)
        {
            try
            {
                if (!double.TryParse(initialNumber, out double initialNumberValue) || !double.TryParse(substractionNumber, out double substractionNumberValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                var answer = _calculateService.CalculateSubtraction(initialNumberValue, substractionNumberValue);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Multiplication([FromQuery] string firstMultiplier, [FromQuery] string secondMultiplier)
        {
            try
            {
                if (!double.TryParse(firstMultiplier, out double firstMultiplierValue) || !double.TryParse(secondMultiplier, out double secondMultiplierValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                var answer = _calculateService.CalculateMultiplication(firstMultiplierValue, secondMultiplierValue);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Division([FromQuery] string dividend, [FromQuery] string divider)
        {
            try
            {
                if (!double.TryParse(dividend, out double dividendValue) || !double.TryParse(divider, out double dividerValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                if (dividerValue == 0)
                    throw new DivideByZeroException("Вы не можете разделить на 0");
                var answer = _calculateService.CalculateDivision(dividendValue, dividerValue);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Pow([FromQuery] string initialNumber, [FromQuery] string power)
        {
            try
            {
                if (!double.TryParse(initialNumber, out double initialNumberValue) || !double.TryParse(power, out double powerValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                var answer = _calculateService.CalculatePow(initialNumberValue, powerValue);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult SquareRoot([FromQuery] string initialNumber, [FromQuery] string rootDegree)
        {
            try
            {
                if (!double.TryParse(initialNumber, out double initialNumberValue) || !double.TryParse(rootDegree, out double rootDegreeValue))
                {
                    throw new WrongDataTypeException("Введён не правильный тип данных");
                }

                if(rootDegreeValue % 2 == 0 && initialNumberValue < 0)
                {
                    throw new NumberLessThanZeroException("Число под корнем не может быть меньше 0, при чётном оснавании корня");
                }

                var answer = _calculateService.CalculateSquareRoot(initialNumberValue, rootDegreeValue);

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
