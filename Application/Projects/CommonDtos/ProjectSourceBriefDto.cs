using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.CommonDtos
{
    public class ProjectSourceDto : IMapFrom<ProjectSource>
    {
        public string SourceUrl { get; set; }
        public ProjectSourceType Type { get; set; }
    }
}
