using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDTO>> GetByEmail(string email)
        {
            return Ok(_service.GetByEmail(email));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Incluir([FromBody] UserDTO user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            return new ObjectResult(await _service.Save(user));
        }

    }
}
