﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
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
    }
}
