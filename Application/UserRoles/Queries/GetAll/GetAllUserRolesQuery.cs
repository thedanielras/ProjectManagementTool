using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserRoles.Queries.GetAll
{
    public class GetAllUserRolesQuery : IRequest<IEnumerable<GetAllUserRolesRoleDto>>
    {
    }

    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<GetAllUserRolesRoleDto>>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUserRolesQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllUserRolesRoleDto>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserRoles
                .ProjectTo<GetAllUserRolesRoleDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
