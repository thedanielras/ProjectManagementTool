using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> AllUsers { get; }
        User GetUserByName(string userName);
        void AddUser(User user);
    }
}
