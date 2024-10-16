using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdvBoard.Contracts.User;
using AdvBoard.AppServices.Helpers;
using Microsoft.AspNetCore.Http;

namespace AdvBoard.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {

        private readonly IJwtProvider _jwtProvider;
        
        public AuthorizationController(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<bool> Login(AuthDto dto)
        {
            // todo Проверяем пароль

            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Role, dto.Login));
            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext
            //    .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            var token = _jwtProvider.GenerateToken(dto);
            HttpContext.Response.Cookies.Append("inn-cookies", token);

            return true;
        }
    }
}
