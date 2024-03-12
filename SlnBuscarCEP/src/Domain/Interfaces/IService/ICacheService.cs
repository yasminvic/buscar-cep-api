using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IService
{
    public interface ICacheService
    {
        Task Set(string key, string cep);

        Task<string> Get(string key);
    }
}
