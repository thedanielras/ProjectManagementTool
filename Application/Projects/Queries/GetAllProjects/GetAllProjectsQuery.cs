using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Projects.Queries.CommonDtos;
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
            .Include(p => p.ResponsibleUser)
            .Include(p => p.Department)
            .ToListAsync();

            if (projects == null)
            {
                throw new NotFoundException("Something went wrong");
            }
            
            var projectDtoList = new List<GetAllProjectsProjectDto>();
            foreach(var project in projects)
            {
                var projectDto = _mapper.Map<GetAllProjectsProjectDto>(project);
                if(project.ForeignResponsibleUserId != null)
                {
                    var foreignResponsibleUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == project.ForeignResponsibleUserId);
                    if (foreignResponsibleUser != null)
                    {
                        projectDto.ForeignResponsibleUser = _mapper.Map<UserBriefDto>(foreignResponsibleUser);
                    }                  
                }
                projectDtoList.Add(projectDto);
            }

            return Result.SuccessWithJsonPayload(projectDtoList);
        }
    }
}
