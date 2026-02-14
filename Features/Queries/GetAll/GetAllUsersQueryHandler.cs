using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.DTO;

namespace UserManagement.Features.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserDto>>(user);
        }
    }
}
