using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
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
                return _dbContext.Projects
                    .Include(p => p.ResponsibleUser)
                    .Include(p => p.ProjectSources)
                    .Include(p => p.Department)
                    .ToList();
            }
        }

        public bool AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            var result = _dbContext.SaveChanges();
            return result != 0;
        }

        public Project GetProjectById(Guid projectId)
        {
            return _dbContext.Projects
                    .Include(p => p.ResponsibleUser)
                    .Include(p => p.ProjectSources)
                    .Include(p => p.Department)
                    .FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
