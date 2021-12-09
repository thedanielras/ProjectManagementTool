using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Projects.Queries.CommonDtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Commands.Remove 
{
    public class RemoveProjectCommand : IRequest<Result>
    {
        public Guid ProjectId { get; set; }
    }

    public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommand, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public RemoveProjectCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId);

            if (project == null)
            {
                throw new NotFoundException($"Project with id {request.ProjectId} was not found");
            }
            
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);

            var projectOperationResultDto = _mapper.Map<ProjectOperationResultDto>(project);
            return Result.SuccessWithJsonPayload(projectOperationResultDto);
        }
    }
}