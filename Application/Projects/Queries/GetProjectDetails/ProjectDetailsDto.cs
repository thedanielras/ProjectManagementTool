using Application.Common.Mappings;
using Application.Projects.Queries.CommonDtos;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsDto : IMapFrom<Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }

        public DepartmentBriefDto Department { get; set; }

        public UserBriefDto ResponsibleUser { get; set; }
        public UserBriefDto ForeignResponsibleUser { get; set; }
        public IEnumerable<ProjectSourceDto> ProjectSources { get; set; }
    }  
}
