using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Projects.Queries.CommonDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Result>
    {  
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public Guid? ForeignResponsibleUserId { get; set; }
        public IEnumerable<ProjectSourceDto> ProjectSources { get; set; }
        public class ProjectSourceDto
        {
            public string SourceUrl { get; set; }
            public ProjectSourceType Type { get; set; }
        }
    }

    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Result> 
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public CreateProjectHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project();
            entity.Name = request.Name;
            entity.DepartmentId = request.DepartmentId;
            entity.ResponsibleUserId = request.ResponsibleUserId;
            entity.ForeignResponsibleUserId = request.ForeignResponsibleUserId;
            entity.ProjectSources = request.ProjectSources.Select(ps => new ProjectSource { SourceUrl = ps.SourceUrl, Type = ps.Type }).ToList();

            if (entity == null)
            {
                return Result.Error(new List<string> { "Error creating project" });
            }

            _context.Projects.Add(entity);
            var id = await _context.SaveChangesAsync(cancellationToken);
            var projectOperationResultDto = _mapper.Map<ProjectOperationResultDto>(entity);
            return Result.SuccessWithJsonPayload(projectOperationResultDto);
        }
    }

}
