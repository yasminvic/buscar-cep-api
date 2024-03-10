using Domain.Entity;
using Domain.Interfaces.IRepository;
using Infra.Data.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLServerContext _context;

        public UserRepository(SQLServerContext context)
        {
            _context = context;
        }

        public async Task<int> Save(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}
