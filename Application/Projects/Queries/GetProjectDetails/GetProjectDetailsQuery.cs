using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Projects.Queries.CommonDtos;

namespace Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsDto>
    {
        public Guid ProjectId { get; set; } 
    }

    public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsDto>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectDetailsQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                .Where(p => p.ProjectId == request.ProjectId)
                .Include(p => p.Department)
                .Include(p => p.ResponsibleUser)
                .Include(p => p.ProjectSources)
                .SingleOrDefaultAsync();

            if(project == null)
            {
                throw new NotFoundException($"Project with id {request.ProjectId} was not found.");
            }

            ProjectDetailsDto projectDto =_mapper.Map<ProjectDetailsDto>(project);

            if(project.ForeignResponsibleUserId != null)
            {
                var foreignUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == project.ForeignResponsibleUserId);
                if(foreignUser != null)
                {
                    projectDto.ForeignResponsibleUser = _mapper.Map<UserBriefDto>(foreignUser);
                }
            }

            return projectDto;
        }
    }
}