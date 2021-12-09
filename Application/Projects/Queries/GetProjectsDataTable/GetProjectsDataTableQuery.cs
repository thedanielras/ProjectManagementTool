using Application.Common.Interfaces;
using Application.DataTables;
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

namespace Application.Projects.Queries.GetProjectsDataTable
{
    public class GetProjectsDataTableQuery : DataTablesRequest, 
                                             IRequest<DataTablesResponse<GetProjectsDataTableProjectDto>>
    {
    }

    public class GetProjectsDataTableQueryHandler : IRequestHandler<GetProjectsDataTableQuery, DataTablesResponse<GetProjectsDataTableProjectDto>>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetProjectsDataTableQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTablesResponse<GetProjectsDataTableProjectDto>> Handle(GetProjectsDataTableQuery request, CancellationToken cancellationToken)
        {
            int pageSize = request.Length < 1 ? 1 : request.Length;
            string globalSeach = request.Search.Value ?? "";

            var allProjectsCount = await _context.Projects.CountAsync();

            var filteredProjectsCount = await _context.Projects
                .Where(p => p.Name.Contains(globalSeach) ||
                            p.Department.Name.Contains(globalSeach) ||
                            p.ResponsibleUser.Name.Contains(globalSeach))
                .CountAsync();

            var projectsQuery = _context.Projects
                .Where(p => p.Name.Contains(globalSeach) || p.Department.Name.Contains(globalSeach))
                .Skip(request.Start)
                .Take(pageSize)
                .Include(p => p.ResponsibleUser)
                .Include(p => p.Department)
                .ProjectTo<GetProjectsDataTableProjectDto>(_mapper.ConfigurationProvider);

            var order = request.Order.FirstOrDefault();

            if (order != null)
            {
                int columnIndexToOrder = order.Column;
                bool isAscendingOrdering = order.Dir == OrderDir.Asc.Value;

                switch (columnIndexToOrder) 
                {
                    case 0:
                        projectsQuery = isAscendingOrdering ? projectsQuery.OrderBy(p => p.Name) :
                                                              projectsQuery.OrderByDescending(p => p.Name);
                        break;
                    //case 1:
                    //    projectsQuery = isAscendingOrdering ? projectsQuery.OrderBy(p => p.Department.Name) :
                    //                                          projectsQuery.OrderByDescending(p => p.Department.Name);
                    //    break;
                    //case 2:
                    //    projectsQuery = isAscendingOrdering ? projectsQuery.OrderBy(p => p.ResponsibleUser.Name) :
                    //                                          projectsQuery.OrderByDescending(p => p.ResponsibleUser.Name);
                    //    break;
                }

            }

            var projects = await projectsQuery.ToListAsync();
            var response = new DataTablesResponse<GetProjectsDataTableProjectDto>(request.Draw, allProjectsCount, filteredProjectsCount, projects);
            
            return response;
        }
    }
}
