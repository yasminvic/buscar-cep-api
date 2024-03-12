using Domain.Entity;
using Domain.Interfaces.IRepository;
using Infra.Data.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public  List<User> GetAll()
        {
            return  _context.Users.ToList();
        }

        public async Task<User> GetByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();
        }

        public async Task<int> Save(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}
