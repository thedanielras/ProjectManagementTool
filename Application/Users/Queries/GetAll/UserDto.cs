using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetAllQuery
{
    public class UserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
