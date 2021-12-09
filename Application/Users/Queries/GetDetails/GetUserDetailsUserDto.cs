using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetDetails
{
    public class GetUserDetailsUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public GetUserDetailsRoleDto Role { get; set; }
        public IEnumerable<GetUserDetailsProjectDto> Projects { get; set; }
    }
}
