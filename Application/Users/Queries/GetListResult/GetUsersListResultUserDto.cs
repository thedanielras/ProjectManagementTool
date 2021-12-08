using Application.Common.Mappings;
using Application.Users.Queries.GetListResult;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetList
{
    public class GetUsersListResultUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public GetUsersListResultUserRoleDto Role { get; set; }
    }
}
