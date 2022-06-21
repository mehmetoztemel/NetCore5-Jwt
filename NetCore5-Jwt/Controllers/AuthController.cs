using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore5_Jwt.Models;
using NetCore5_Jwt.Services;

namespace NetCore5_Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult GetToken(LoginModel loginModel)
        {
            return ActionResultInstance(_tokenService.CreateToken(loginModel));
        }
    }
}
