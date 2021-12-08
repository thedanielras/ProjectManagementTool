using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Queries.GetProjectForRemoval
{
    public class GetProjectForRemovalQuery : IRequest<ProjectForRemovalDto>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }

    public class GetProjectForRemovalQueryHandler : IRequestHandler<GetProjectForRemovalQuery, ProjectForRemovalDto>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectForRemovalQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectForRemovalDto> Handle(GetProjectForRemovalQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId);
            
            if (project == null) { throw new NotFoundException($"Project with id {request.ProjectId} was not found"); }
            
            return _mapper.Map<ProjectForRemovalDto>(project);            
        }
    }
}