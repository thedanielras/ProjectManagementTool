using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Users.Common.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.AdminCreate
{
    public class AdminCreateUserCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }

    public class AdminCreateUserCommandHandler : IRequestHandler<AdminCreateUserCommand, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public AdminCreateUserCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AdminCreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUserTest = await _context.Users.FirstOrDefaultAsync(u => u.Name == request.Name);
            if (existingUserTest != null) 
            {
                throw new ValidationException("Creation failed. An user with that name is already registered.");
            }

            var entity = new User();
            entity.Name = request.Name;
            entity.Password = request.Password;
            entity.RoleId = request.RoleId;
                       
            var user = _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var userResultDto = _mapper.Map<UserResultDto>(entity);
            return Result.SuccessWithJsonPayload(userResultDto);
        }
    }

}