using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountServices _accountServices;
        private IConfiguration _configuration;
        public AccountController(IAccountServices accountServices, IConfiguration configuration) // dependency injection 
        {
            _accountServices = accountServices;
            _configuration = configuration;
        }

        [HttpPost("AccountLogin")]
        public async Task<ActionResult> AccountLogin(AccountLoginRequestData requestData)
        {
            var returnData = new LoginResponseData();
            try
            {
                // Bước 1: Gọi login để lấy thông tin tài  khoản

                var result = await _accountServices.AccountLogin(requestData);

                if (result.ReturnCode < 0)
                {
                    return Ok(result);
                }

                // Bước 2 : Tạo token 
                // Bước 2.1 tạo claims để lưu thông tin user
                var user = result.user;

                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.PrimarySid, user.UserID.ToString()),
                };

                // Bước 2.2 tạo token dựa trên claims ở bước 2.1
                var newtoken = CreateToken(authClaims);

                // bước 2.3 tạo refeshtoken
                var expriredDays = Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]);
                var refeshtokenExpired = DateTime.Now.AddDays(expriredDays);

                var refeshtoken = GenerateRefreshToken();
                var req = new Account_UpdateRefeshTokenRequestData
                {
                    Exprired = refeshtokenExpired,
                    RefeshToken = refeshtoken,
                    UserId = user.UserID,
                };
                var rs = await _accountServices.Account_UpdateRefeshToken(req);

                // Bước 3: trả về token
                returnData.ReturnCode = result.ReturnCode;
                returnData.ReturnMessage = result.ReturnMessage;
                returnData.token = new JwtSecurityTokenHandler().WriteToken(newtoken);

                return Ok(returnData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            // Claims 
            // SecretKey
            // TokenValidityInMinutes
            // thuật toán sử dụng HmacSha256

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
