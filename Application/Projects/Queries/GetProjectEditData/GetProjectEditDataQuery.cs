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

namespace Application.Projects.Queries.GetProjectEditData
{
    public class GetProjectEditDataQuery : IRequest<ProjectEditDto>
    {
        public Guid ProjectId { get; set; }
    }

    public class GetProjectEditDataQueryHandler : IRequestHandler<GetProjectEditDataQuery, ProjectEditDto>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectEditDataQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ProjectEditDto> Handle(GetProjectEditDataQuery request, CancellationToken cancellationToken)
        {
            return _context.Projects
               .Where(p => p.ProjectId == request.ProjectId)
               .ProjectTo<ProjectEditDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();
        }
    }
}
