using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ProjectSource
    {
        public int Id { get; set; }
        public Uri SourceUri { get; set; }
        public ProjectSourceType Type { get; set; }
    }

    public enum ProjectSourceType 
    { 
        Github = 0,
        Gitlab = 1,
        Other = 2
    }
}
