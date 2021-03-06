using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> AllProjects { get; }
        Project GetProjectById(Guid projectId);
        bool AddProject(Project project);
    }
}
