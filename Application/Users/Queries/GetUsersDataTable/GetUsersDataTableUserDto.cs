using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Queries.GetUsersDataTableQuery
{
    public class GetUsersDataTableUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public GetUsersDataTableUserRole Role { get; set; }
    }
}