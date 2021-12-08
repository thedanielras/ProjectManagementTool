using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Projects.Queries.CommonDtos
{
    public class ProjectOperationResultDto : IMapFrom<Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }
}