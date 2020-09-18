﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE_test.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CORE_test.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HomeController : ControllerBase
  {

    private readonly ILoggerService _logger;

    public HomeController(ILoggerService logger )
    {
      _logger = logger;
    }


    /// Test Get
    /// </summary>
    /// <returns></returns>
    // GET: api/<HomeController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      _logger.LogInfo("test inf7777777o get");
      return new string[] { "value1", "value2" };
    }

    // GET api/<HomeController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<HomeController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<HomeController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<HomeController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
