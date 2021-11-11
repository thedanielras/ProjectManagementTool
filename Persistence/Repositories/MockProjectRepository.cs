using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Persistence.Repositories
{
    public class MockProjectRepository : IProjectRepository
    {
        public IEnumerable<Project> AllProjects => new List<Project>
        {
            new Project 
            { 
                ProjectId = 1,
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
                ProjectId = 2,
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

        public Project GetProjectById(int projectId)
        {
            return AllProjects.FirstOrDefault(p => p.ProjectId == projectId);
        }
    }
}
