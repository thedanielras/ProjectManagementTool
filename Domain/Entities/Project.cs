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

        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public IEnumerable<ProjectSource> ProjectSources { get; private set; }
    }
}
