using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserDTO user)
        {
            var found = _userService.GetAll().Where(userDTO => userDTO.email == user.email)
                                             .Where(userDTO => userDTO.password == user.password)
                                             .FirstOrDefault();

            if(found == null)
            {
                return BadRequest("Login errado! Email ou Senha incorretos");
            }

            var token = CriarToken();
            return Ok(new { token });
        }

        private string CriarToken()
        {
            const string SECRET_KEY = "9fbbdd98-f2f4-4673-b48e-083ec1be44dc";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yasminvic",
                audience: "buscar_cep",
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
