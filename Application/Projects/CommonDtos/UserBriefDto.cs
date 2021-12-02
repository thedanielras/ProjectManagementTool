using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Queries.CommonDtos
{
    public class UserBriefDto : IMapFrom<User>
    {
        public string Name { get; set; }
    }
}
