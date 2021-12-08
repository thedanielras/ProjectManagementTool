using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
