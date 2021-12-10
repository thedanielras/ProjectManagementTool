using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Queries.GetUsersDataTableQuery
{
    public class GetUsersDataTableUserRole : IMapFrom<Role>
    {
        public string Name { get; set; }
    }  
}