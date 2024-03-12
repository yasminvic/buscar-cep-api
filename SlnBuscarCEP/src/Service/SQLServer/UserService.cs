using Domain.DTO;
using Domain.Interfaces.IRepository;
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
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserDTO> GetAll()
        {
            return _repository.GetAll().Select(x => new UserDTO(){
                id = x.Id,
                email = x.Email,
                password = x.Password
            }).ToList();
                
           
        }

        public async Task<UserDTO> GetByEmail(string email) 
        {
            UserDTO user = new UserDTO();
            return user.MapToDTO(await _repository.GetByEmail(email));
                
        }

        public async Task<int> Save(UserDTO user)
        {
            return await _repository.Save(user.MapToEntity());
        }
    }
}
