using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetList
{
    public class GetUsersListResultQuery : IRequest<Result>
    {
    }

    public class GetUsersListResultQueryHandler : IRequestHandler<GetUsersListResultQuery, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersListResultQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetUsersListResultQuery request, CancellationToken cancellationToken)
        {
            var userDtos = await _context.Users
                .ProjectTo<GetUsersListResultUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.SuccessWithJsonPayload(userDtos);
        }
    }
}
