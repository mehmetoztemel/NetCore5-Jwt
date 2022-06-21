using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace NetCore5_Jwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            string[] values = new string[] { "value1", "value2" };
            return Ok(values);
        }
    }
}
