using Domain.DTO;
using Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.SQLServer
{
    public class UserService : IUserService
    {
        public Task<int> Save(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
