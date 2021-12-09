using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Users.Common.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Remove
{
    public class RemoveUserCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
    }

    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public RemoveUserCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<Result> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"User with provided id was not found");
            }
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            var userResultDto = _mapper.Map<UserResultDto>(user);
            return Result.SuccessWithJsonPayload(userResultDto);
        }        
    }

}