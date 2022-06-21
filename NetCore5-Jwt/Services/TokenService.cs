using Microsoft.IdentityModel.Tokens;
using NetCore5_Jwt.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore5_Jwt.Services
{
    public class TokenService : ITokenService
    {
        public CustomResponse CreateToken(LoginModel loginModel)
        {
            if (loginModel == null) throw new ArgumentNullException(nameof(loginModel));

            var tokenResponse = new TokenResponse();
            if (loginModel.UserName == "admin" && loginModel.Password == "admin")
            {
                #region Token_Create
                //Security Key'in simetriğini tanımlıyoruz.
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("core_api_example"));

                //Şifrelenmiş kimliği oluşturuyoruz.
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Oluşturulacak token ayarlarını veriyoruz.
                tokenResponse.Expiration = DateTime.Now.AddDays(1);
                var claims = new List<Claim> {
                new Claim("User", loginModel.UserName),
                //new Claim(ClaimTypes.Name , loginModel.UserName)
                };

                JwtSecurityToken securityToken = new JwtSecurityToken(
                    expires: tokenResponse.Expiration, //Token süresini 1 gün olarak belirliyorum
                    notBefore: DateTime.Now, //Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
                    signingCredentials: signingCredentials, // Şifrelenmiş kimliği buraya yazıyoruz
                    claims: claims //Token içinde tutulacak kullanici bilgilerini dolduruyoruz
                    );
                //Token oluşturucu sınıfında bir örnek alıyoruz.
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                //Token üretiyoruz.
                tokenResponse.Token = tokenHandler.WriteToken(securityToken);
                #endregion

                return CustomResponse.ReturnSuccess(tokenResponse, 200);
            }
            else
            {
                return CustomResponse.ReturnError("User informations wrong", 400, true);
            }

            throw new System.NotImplementedException();
        }
    }
}
