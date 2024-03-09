using Domain.Entity;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository
{
    public interface ICepRepository
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ResponseApi>> ObterCep(string cep);
    }
}
