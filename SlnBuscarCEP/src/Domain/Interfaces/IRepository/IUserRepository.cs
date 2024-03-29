﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        Task<User> GetByEmail(string email);
        Task<int> Save(User user);
    }
}
