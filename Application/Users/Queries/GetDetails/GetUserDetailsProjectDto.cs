using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetDetails
{
    public class GetUserDetailsProjectDto : IMapFrom<Project>
    {
        public string Name { get; set; }
    }
}
