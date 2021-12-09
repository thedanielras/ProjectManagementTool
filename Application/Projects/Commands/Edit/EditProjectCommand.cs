using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Projects.Queries.CommonDtos;
using Application.Projects.Queries.GetProjectEditData;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Commands.Edit 
{
    public class EditProjectCommand : IRequest<Result> 
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }              
        public Guid ResponsibleUserId { get; set; }
        public Guid? ForeignResponsibleUserId { get; set; }
        public IEnumerable<ProjectSourceEditDto> ProjectSources { get; set; }
    }

    public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public EditProjectCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var projectWithSameDataExists = await _context.Projects
                .FirstOrDefaultAsync(p => p.Name == request.Name 
                        && p.DepartmentId == request.DepartmentId 
                        && p.ProjectId != request.ProjectId) != null;
            
            if(projectWithSameDataExists)
            {
                throw new ValidationException("Another project with the same name and department already exists.");
            }
            
            var entity = _context.Projects.SingleOrDefault(p => p.ProjectId == request.ProjectId);
            
            if (entity == null)
            {
                throw new NotFoundException($"Project with id {request.ProjectId} was not found!");
            }
            
            entity.Name = request.Name;
            entity.DepartmentId = request.DepartmentId;
            entity.ResponsibleUserId = request.ResponsibleUserId;
            entity.ForeignResponsibleUserId = request.ForeignResponsibleUserId;
            entity.ProjectSources = request.ProjectSources.Select(ps => new ProjectSource { ProjectSourceId = ps.ProjectSourceId, SourceUrl = ps.SourceUrl, Type = ps.Type }).ToList();
            
            await _context.SaveChangesAsync(cancellationToken);
            var projectOperationResultDto = _mapper.Map<ProjectOperationResultDto>(entity);
            return Result.SuccessWithJsonPayload(projectOperationResultDto);
        }
    }

}