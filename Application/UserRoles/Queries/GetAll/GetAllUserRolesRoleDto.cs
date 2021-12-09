using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserRoles.Queries.GetAll
{
    public class GetAllUserRolesRoleDto : IMapFrom<Role>
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
    }
}
