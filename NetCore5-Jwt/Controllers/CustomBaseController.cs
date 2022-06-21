using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore5_Jwt.Models;

namespace NetCore5_Jwt.Controllers
{
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult ActionResultInstance(CustomResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
