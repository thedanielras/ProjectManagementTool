using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetByName
{
    public class GetUserByNameQuery : IRequest<User>
    {
        public GetUserByNameQuery(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; private set; }
    }

    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, User>
    {
        private readonly IProjectManagementToolDbContext _context;

        public GetUserByNameQueryHandler(IProjectManagementToolDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == request.UserName);
        }
    }
}