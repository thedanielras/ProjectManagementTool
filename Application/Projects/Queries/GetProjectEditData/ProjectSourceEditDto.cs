using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.GetProjectEditData
{
    public class ProjectSourceEditDto : IMapFrom<ProjectSource>
    {
        public Guid ProjectSourceId { get; set; }
        public string SourceUrl { get; set; }
        public ProjectSourceType Type { get; set; }
    }
}
