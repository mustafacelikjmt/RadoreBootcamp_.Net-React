using JwtRadoreOrnek.Models;
using JwtRadoreOrnek.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtRadoreOrnek.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        private static readonly string[] cities = { "İstanbul", "Ankara", "İzmir", "Bursa", "Adana", "Eskişehir" };
        private readonly IUserService _userService;

        public SamplesController(IUserService userService) => _userService = userService;

        [HttpGet]
        [Authorize]
        public IActionResult GetCities() => Ok(cities);

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userService.Authenticate(model.UserName, model.Password);
            if (user == null) return BadRequest("Bilgileriniz Hatalı.");

            return Ok(new { Username = user.Value.userName, Token = user.Value.token });
        }
    }
}