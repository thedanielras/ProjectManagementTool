using Application.Common.Mappings;
using Application.Projects.Queries.CommonDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.GetProjectEditData
{
    public class ProjectEditDto : IMapFrom<Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentBriefDto Department { get; set; }
              
        public Guid ResponsibleUserId { get; set; }
        public UserBriefDto ResponsibleUser { get; set; }
        public Guid? ForeignResponsibleUserId { get; set; }
        public UserBriefDto ForeignResponsibleUser { get; set; }
        public IEnumerable<ProjectSourceEditDto> ProjectSources { get; set; }
    }
}
