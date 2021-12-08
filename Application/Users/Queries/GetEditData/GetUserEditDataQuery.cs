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

namespace Application.Users.Queries.GetEditData
{
    public class GetUserEditDataQuery : IRequest<GetUserEditDataUserDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserEditDataQueryHandler : IRequestHandler<GetUserEditDataQuery, GetUserEditDataUserDto>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetUserEditDataQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetUserEditDataUserDto> Handle(GetUserEditDataQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users
                .ProjectTo<GetUserEditDataUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.UserId == request.UserId);
            
            if (user == null)
            {
                throw new NotFoundException("User with the provided id not found.");
            }

            return user;
        }
    }
}
