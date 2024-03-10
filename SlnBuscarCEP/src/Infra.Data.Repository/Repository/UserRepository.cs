using Domain.Entity;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<int> Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
