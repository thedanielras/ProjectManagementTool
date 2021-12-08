using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Projects.Queries.GetProjectForRemoval
{
    public class ProjectForRemovalDto : IMapFrom<Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }
}