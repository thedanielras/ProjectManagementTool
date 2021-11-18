using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}