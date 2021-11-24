using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos
{
    public class ProjectsListDto
    {
        public IEnumerable<ProjectDto> Projects { get; set; }
    }
}
