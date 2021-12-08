using Application.Common.Exceptions;
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

namespace Application.Users.Queries.GetDetails
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsUserDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsUserDto>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserDetailsUserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .ProjectTo<GetUserDetailsUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.UserId == request.UserId);

            if(user == null)
            {
                throw new NotFoundException("User with the provided id not found.");
            }

            return user;
        }
    }
}
