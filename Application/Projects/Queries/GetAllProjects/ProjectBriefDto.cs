using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.GetAllProjects
{
    public  class ProjectBriefDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DepartmentDto Department { get; set; }
        public UserDto ResponsibleUser { get; set; }
    }

    public class DepartmentDto
    {
        public string Name { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
    }
}
