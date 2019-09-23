using Microsoft.AspNetCore.Mvc;
using cataloteca.algorithms.LevenshteinDistance;
using System.Collections.Generic;
using CatalotecaWeb.Domain.Interfaces.Services.User;
using System;
using CatalotecaWeb.Domain.Entities;

namespace CatalotecaWeb.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calcController : ControllerBase
    {
        private IUserService _service;

        public calcController(IUserService service)
        {
            _service = service;
        }
        [HttpGet("{ef}")]
        public IActionResult Get(Guid id,string ef)
        {
            string reference = ef;
                        
            List<string> exampleList = new List<string>(new string[] {
            "example 1",
            "example 2",
            "example 3"
            });
            var bothCalc = new LevenshteinInput(reference, exampleList);
            var data = bothCalc.CallLevenstheinCalc(similarity:true, distance:true);
            return Ok(data);
        }
        
    }
}