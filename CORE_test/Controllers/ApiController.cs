using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_test.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApiController : ControllerBase
  {
  [HttpGet]
    public IActionResult Index()
    {
     return Ok("Tout a fonctionner");
    }
  }
}
