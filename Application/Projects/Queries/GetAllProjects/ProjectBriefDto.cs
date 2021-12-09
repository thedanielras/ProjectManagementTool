using Application.Common.Mappings;
using Application.Projects.Queries.CommonDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.GetAllProjects
{
    public  class ProjectBriefDto : IMapFrom<Project>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DepartmentBriefDto Department { get; set; }
        public UserBriefDto ResponsibleUser { get; set; }
        public UserBriefDto ForeignResponsibleUser { get; set; }
    }   
}
