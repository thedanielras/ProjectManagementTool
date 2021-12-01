using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ProjectSource
    {
        public Guid ProjectSourceId { get; set; }
        public string SourceUrl { get; set; }
        public ProjectSourceType Type { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }   
}
