using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly ProjectManagementToolDbContext _dbContext;
        public UserRepository(ProjectManagementToolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> AllUsers => _dbContext.Users.ToList();

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserByName(string userName)
        {
            return _dbContext.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault();
        }
    }
}
