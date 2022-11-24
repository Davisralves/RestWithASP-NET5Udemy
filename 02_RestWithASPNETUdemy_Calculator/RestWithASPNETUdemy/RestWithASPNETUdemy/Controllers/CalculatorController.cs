using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondsNumber}")]
        public IActionResult Sum(string firstNumber, string secondsNumber)
        {
            if(IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondsNumber}")]
        public IActionResult Sub(string firstNumber, string secondsNumber)
        {
            if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var subtraction = ConvertDecimal(firstNumber) - ConvertDecimal(secondsNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("mult/{firstNumber}/{secondsNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondsNumber)
        {
            if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var sum = ConvertDecimal(firstNumber) * ConvertDecimal(secondsNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondsNumber}")]

        public IActionResult Division(string firstNumber, string secondsNumber)
        {
            if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var sum = ConvertDecimal(firstNumber) / ConvertDecimal(secondsNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("med/{firstNumber}/{secondsNumber}")]
        public IActionResult Media(string firstNumber, string secondsNumber)
        {
            if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var sum = (ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber)) / 2;
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Media(int firstNumber)
        {
                var sum = Math.Sqrt(firstNumber);
                return Ok(sum.ToString());
            
            return BadRequest("invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertDecimal(string strNumber)
        {
            decimal decimalNumber;
            if(decimal.TryParse(strNumber, out decimalNumber))
            {
                return decimalNumber;
            }
            return 0;
        }
    }
}
