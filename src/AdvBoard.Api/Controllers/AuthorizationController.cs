using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdvBoard.Contracts.User;
using AdvBoard.AppServices.Helpers;
using Microsoft.AspNetCore.Http;
using AdvBoard.AppServices.Authorization.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace AdvBoard.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {

        private readonly IJwtProvider _jwtProvider;
        private readonly IUserService _userService;
        
        public AuthorizationController(IJwtProvider jwtProvider, IUserService userService)
        {
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthDto dto, CancellationToken cancellationToken)
        {

            string token = await _userService.LoginAsync(dto, cancellationToken);
            if (token == "не верный логин или пароль!" ) 
            {
                return StatusCode((int)HttpStatusCode.Forbidden, token);
            }

            HttpContext.Response.Cookies.Append("inn-cookies", token);
            var result = "Успех!";

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserUpdateRequest userRegister, CancellationToken cancellationToken)
        {
            // пока все будут юзеры
            userRegister.Role = "User";


            var result = await _userService.RegisterAsync(userRegister, cancellationToken);
            if (result == "такой логин уже зарегистрирован выберете другой!")
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, result);
            }

            return StatusCode((int)HttpStatusCode.OK, result);
        }
    }
}
