using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Enums;

namespace Infrastructure.Persistence.Repositories
{
    public class MockProjectRepository : IProjectRepository
    {
        public IEnumerable<Project> AllProjects => new List<Project>
        {
            new Project 
            { 
                ProjectId = new Guid(),
                Name = "SomeProject1",
                Department = new Department { Name = ".NET" },
                ProjectSources = new List<ProjectSource> 
                { 
                    new ProjectSource 
                    { 
                        SourceUrl = "http://test.com",
                        Type = ProjectSourceType.Other
                    }
                }
            },
            new Project
            {
                ProjectId = new Guid(),
                Name = "SomeProject2",
                Department = new Department { Name = "Java" },
                ProjectSources = new List<ProjectSource>
                {
                    new ProjectSource
                    {
                        SourceUrl = "http://test.com",
                        Type = ProjectSourceType.Other
                    }
                }
            }
        };

        public bool AddProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(Guid projectId)
        {
            return AllProjects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public Project GetProjectById(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
