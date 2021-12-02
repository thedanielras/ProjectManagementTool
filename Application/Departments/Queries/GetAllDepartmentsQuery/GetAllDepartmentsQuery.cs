using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Departments.Queries.GetAllDepartmentsQuery
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmetnDto>>
    {
    }

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmetnDto>>
    {

        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmetnDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.ProjectTo<DepartmetnDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
