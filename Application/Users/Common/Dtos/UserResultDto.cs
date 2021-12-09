using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Common.Dtos
{
    public class UserResultDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}