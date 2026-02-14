using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.DTO;

namespace UserManagement.Features.Queries.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            return user == null ? null : _mapper.Map<UserDto>(user);
        }
    }
}
