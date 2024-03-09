using Domain.Entity;
using Domain.Interfaces.IRepository;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repository
{
    public class CepRepository : ICepRepository
    {
        public Task<ApiResponse<ResponseApi>> ObterCep(string cep)
        {

        }
    }
}
