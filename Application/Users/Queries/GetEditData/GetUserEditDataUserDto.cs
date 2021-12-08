using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetEditData
{
    public class GetUserEditDataUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

    }
}
