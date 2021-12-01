using Application.Common.Interfaces;
using Application.Common.Models;
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
    public  class GetAllProjectsQuery : IRequest<Result>
    {
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .ProjectTo<ProjectBriefDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (projects != null)
            {
                return Result.SuccessWithJsonPayload(projects);
            } else 
            {
                return Result.Error(new List<string> { "Error getting projects!" });
            }
        }
    }
}
