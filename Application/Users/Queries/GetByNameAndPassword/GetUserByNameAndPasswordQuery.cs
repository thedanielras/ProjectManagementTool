using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetByNameAndPassword
{
    public class GetUserByNameAndPasswordQuery : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetUserByNameAndPasswordQueryHandler : IRequestHandler<GetUserByNameAndPasswordQuery, User>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByNameAndPasswordQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByNameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == request.UserName && u.Password == request.Password);
        }
    }
}
