using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Remove
{
    public class RemoveUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}