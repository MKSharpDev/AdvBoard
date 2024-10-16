using AdvBoard.Contracts.User;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AdvBoard.AppServices.Helpers
{
    public class JwtProvider: IJwtProvider
    {
        public string GenerateToken(UserDto user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            //надо будет отхардкодить обратно ключ и прикопать поглубже
            var singCred = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("500f8598-2273-482b-a99f-77c9de5a321c")), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: singCred,
                expires: DateTime.UtcNow.AddHours(1));

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result.ToString();
        }
    }
}
