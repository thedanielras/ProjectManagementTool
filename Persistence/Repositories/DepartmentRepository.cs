using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ProjectManagementToolDbContext _dbContext;

        public DepartmentRepository(ProjectManagementToolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> AlLDerartments => _dbContext.Departments.ToList();
    }
}
