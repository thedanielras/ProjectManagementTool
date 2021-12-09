using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Users.Common.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.Edit
{
    public class EditUserCommand : IRequest<Result>, IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }

    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Result>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public EditUserCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<Result> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {            
            User entity = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == request.UserId);

            if(entity == null)
            {
                throw new NotFoundException("User with provided id was not found.");
            }

            entity.Name = request.Name;
            entity.Password = request.Password;
            entity.RoleId = request.RoleId;

            var existingUserTest = await _context.Users.FirstOrDefaultAsync(u => u.Name == entity.Name);
            if (existingUserTest != null) 
            {
                throw new ValidationException("Creation failed. An user with that name is already registered.");
            }           
        
            var userResultDto = _mapper.Map<UserResultDto>(entity);
            
            await _context.SaveChangesAsync(cancellationToken);
            return Result.SuccessWithJsonPayload(userResultDto);
        }
    }
}