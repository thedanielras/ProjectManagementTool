using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Queries.GetAllProjects
{
    public  class GetAllProjectsQuery : IRequest<IEnumerable<ProjectBriefDto>>
    {
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectBriefDto>>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectBriefDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Projects
                .ProjectTo<ProjectBriefDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
