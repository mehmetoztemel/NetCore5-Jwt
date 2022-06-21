using NetCore5_Jwt.Models;
using System.Threading.Tasks;

namespace NetCore5_Jwt.Services
{
    public interface ITokenService
    {
        CustomResponse CreateToken(LoginModel loginModel);
    }
}
