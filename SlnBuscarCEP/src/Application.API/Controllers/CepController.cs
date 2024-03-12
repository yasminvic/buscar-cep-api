using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Application.API.Controllers
{
    [Authorize]
    [ApiController]
    public class CepController : ControllerBase
    {
        private const string MEMORY_KEY = "CEP-";

        private readonly ICepService _service;
        private readonly ICacheService _memoryCache;


        public CepController(ICepService service, ICacheService memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ResponseApiDTO>> ProcuraCep(string cep)
        {
            //Validação CEP
            if (!ValidaCEP(cep))
            {
                return BadRequest("CEP inválido. Por favor, tente novamente!");
            }

            //procurando no cache
            var foundCache = await _memoryCache.Get($"{MEMORY_KEY}{cep}");
            ResponseApiDTO responseCep;

            if (foundCache != null)
            {
                responseCep = JsonSerializer.Deserialize<ResponseApiDTO>(foundCache);
                responseCep.proveniente = "Cache";
                return Ok(responseCep);
            }

            responseCep = await _service.BuscarCep(cep);
            responseCep.proveniente = "ViaCep";

            //Validação
            if(responseCep == null)
            {
                return BadRequest("CEP informado não existe. Por favor, tente novamente!");
            }
            if(responseCep.cep == null)
            {
                return BadRequest("CEP não encontrado na base de dados. Por favor, tente novamente!");
            }

            //salvando no cache
            await _memoryCache.Set($"{MEMORY_KEY}{cep}", JsonSerializer.Serialize(responseCep));

            return Ok(responseCep);
        }


        private bool ValidaCEP(string cep)
        {
            var validacao = new Regex(@"^\d{5}\d{3}$");

            if (!validacao.IsMatch(cep))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
