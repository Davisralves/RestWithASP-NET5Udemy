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
        public IActionResult Get(string firstNumber, string secondsNumber)
        {
            if(IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondsNumber}")]
        public IActionResult Get(string firstNumber, string secondsNumber)
        {
            if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
            {
                var subtraction = ConvertDecimal(firstNumber) - ConvertDecimal(secondsNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("invalid input");
        }

        //public IActionResult Get(string firstNumber, string secondsNumber)
        //{
        //    if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
        //    {
        //        var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("invalid input");
        //}

        //public IActionResult Get(string firstNumber, string secondsNumber)
        //{
        //    if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
        //    {
        //        var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("invalid input");
        //}

        //public IActionResult Get(string firstNumber, string secondsNumber)
        //{
        //    if (IsNumeric(firstNumber) & IsNumeric(secondsNumber))
        //    {
        //        var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondsNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("invalid input");
        //}

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
