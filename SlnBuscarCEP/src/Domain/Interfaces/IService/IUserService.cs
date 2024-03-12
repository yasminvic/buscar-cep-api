using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IService
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        Task<UserDTO> GetByEmail(string email);
        Task<int> Save(UserDTO user);
    }
}
