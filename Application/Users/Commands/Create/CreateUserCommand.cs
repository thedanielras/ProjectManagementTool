using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User();
            entity.Name = request.UserName;
            entity.Password = request.Password;

            var existingUserTest = await _context.Users.FirstOrDefaultAsync(u => u.Name == entity.Name);
            if (existingUserTest != null) 
            {
                throw new ValidationException("This user name already exists");
            }
            
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }        
    }
}
