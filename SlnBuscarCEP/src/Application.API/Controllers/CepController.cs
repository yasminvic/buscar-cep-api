using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;

namespace Application.API.Controllers
{
    [Authorize]
    [ApiController]
    public class CepController : ControllerBase
    {
        private const string MEMORY_KEY = "CEPs";

        private readonly ICepService _service;
        private readonly IMemoryCache _memoryCache;


        public CepController(ICepService service, IMemoryCache memoryCache)
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


            List<ResponseApiDTO> listaCeps = new List<ResponseApiDTO>();

            if (_memoryCache.TryGetValue(MEMORY_KEY, out List<ResponseApiDTO> ceps))
            {
                foreach (var c in ceps)
                {
                    if(c.cep.Replace("-", "") == cep)
                    {
                        c.proveniente = "Cache";
                        return Ok(c);
                    } 
                };
            }

            var cepPesquisado = await _service.BuscarCep(cep);
            cepPesquisado.proveniente = "ViaCep";
            listaCeps.Add(cepPesquisado);
            ceps = listaCeps;

            
            //Validação
            if(cepPesquisado == null)
            {
                return BadRequest("CEP informado não existe. Por favor, tente novamente!");
            }
            if(cepPesquisado.cep == null)
            {
                return BadRequest("CEP não encontrado na base de dados. Por favor, tente novamente!");
            }

            var memoryCacheConfig = new MemoryCacheEntryOptions
            {
                //tempo que vai ficar guardado no cache
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                Size = 2
            };
            _memoryCache.Set(MEMORY_KEY, ceps, memoryCacheConfig);

            return Ok(cepPesquisado);
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
