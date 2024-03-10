﻿using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

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