using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetListResult
{
    public class GetUsersListResultUserRoleDto : IMapFrom<Role>
    {
        public string Name { get; set; }
    }
}
