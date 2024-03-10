using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Authorize]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ResponseApiDTO>> ProcuraCep(string cep)
        {
            var cepPesquisado = await _service.BuscarCep(cep);

            if(cepPesquisado == null)
            {
                return BadRequest();
            }

            return Ok(cepPesquisado);
        }
    }
}
