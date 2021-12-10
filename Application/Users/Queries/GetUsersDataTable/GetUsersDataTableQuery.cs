using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.DataTables;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUsersDataTableQuery
{
    public class GetUsersDataTableQuery : DataTablesRequest, 
                                          IRequest<DataTablesResponse<GetUsersDataTableUserDto>>
    {

    }

    public class GetUsersDataTableQueryHandler : IRequestHandler<GetUsersDataTableQuery, DataTablesResponse<GetUsersDataTableUserDto>>
    {
        private readonly IProjectManagementToolDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersDataTableQueryHandler(IProjectManagementToolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTablesResponse<GetUsersDataTableUserDto>> Handle(GetUsersDataTableQuery request, CancellationToken cancellationToken)
        {
            int pageSize = request.Length < 1 ? 1 : request.Length;
            string globalSeach = request.Search.Value?.ToLower() ?? "";

            var allUsersCount = await _context.Users.CountAsync();

            var filteredUsersQuery = _context.Users.Where(u => u.Name.ToLower().Contains(globalSeach) ||
                                                               u.Role.Name.ToLower().Contains(globalSeach));

            var filteredUsersCount = await filteredUsersQuery.CountAsync();
            var filteredUsersQueryPaginated = filteredUsersQuery
                .Skip(request.Start)
                .Take(pageSize);

            var order = request.Order.FirstOrDefault();
            if (order != null)
            {
                int columnIndexToOrder = order.Column;
                bool isAscendingOrdering = order.Dir == OrderDir.Asc.Value;

                switch (columnIndexToOrder) 
                {
                    case 0:
                        filteredUsersQueryPaginated = isAscendingOrdering ? filteredUsersQueryPaginated.OrderBy(p => p.Name) :
                                                                               filteredUsersQueryPaginated.OrderByDescending(p => p.Name);
                        break;
                    case 1:
                       filteredUsersQueryPaginated = isAscendingOrdering ? filteredUsersQueryPaginated.OrderBy(p => p.Role.Name) :
                                                                              filteredUsersQueryPaginated.OrderByDescending(p => p.Role.Name);
                       break;                 
                }
            }

            var users = await filteredUsersQueryPaginated
                            .Include(u => u.Role)                       
                            .ToListAsync();
            
            var usersDto = _mapper.Map<IEnumerable<GetUsersDataTableUserDto>>(users);
            var response = new DataTablesResponse<GetUsersDataTableUserDto>(request.Draw, allUsersCount, filteredUsersCount, usersDto);
            
            return response;
        }
    }

}