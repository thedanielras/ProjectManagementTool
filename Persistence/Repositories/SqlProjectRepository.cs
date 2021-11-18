using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    class SqlProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementToolDbContext _dbContext;

        public SqlProjectRepository(ProjectManagementToolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Project> AllProjects
        {
            get 
            {
                return _dbContext.Projects.ToList();
            }
        }

        public Project GetProjectById(int projectId)
        {
            return _dbContext.Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
