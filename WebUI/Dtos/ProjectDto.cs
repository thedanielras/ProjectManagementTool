using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos
{
    public class ProjectDto
    {

        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DepartmentDto Department { get; set; }
        public UserDto ResponsibleUser { get; set; }
        public IEnumerable<ProjectSourceDto> ProjectSources { get; set; }
    }
}
