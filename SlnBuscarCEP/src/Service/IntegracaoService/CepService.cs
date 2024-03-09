using Domain.DTO;
using Domain.Entity;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Integracao
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _repository;

        public CepService(ICepRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseApiDTO> BuscarCep(string cep)
        {
            ResponseApiDTO responseApiDTO = new ResponseApiDTO();
            var response = await _repository.ObterCep(cep);

            if(response == null && !response.IsSuccessStatusCode)
            {
                return null;
            }

            return responseApiDTO.MapToDTO(response.Content);
        }
    }
}
