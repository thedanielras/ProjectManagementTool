using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Project
    {
        public Project()
        {
            ProjectSources = new List<ProjectSource>();
        }

        public Guid ProjectId { get; set; }
        public string Name { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public IEnumerable<ProjectSource> ProjectSources { get; set; }

        public Guid ResponsibleUserId { get; set; }
        public Guid? ForeignResponsibleUserId { get; set; }
        public User ResponsibleUser { get; set; }
    }
}
