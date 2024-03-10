using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }



        public User MapToEntity()
        {
            return new User
            {
                Id = id,
                Email = email,
                Password = password
            };
        }

        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                id = user.Id,
                email = user.Email,
                password = user.Password
            };
        }
    }
}
