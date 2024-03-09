using Domain.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IService
{
    public interface ICepService
    {
        Task<ResponseApiDTO> BuscarCep(string cep);
    }
}
