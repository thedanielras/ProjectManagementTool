using Application.Common.Interfaces;
using Application.Users.Queries.GetAllQuery;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetAll
{
    public class GetAllUsersQuery: IRequest<IEnumerable<UserDto>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
