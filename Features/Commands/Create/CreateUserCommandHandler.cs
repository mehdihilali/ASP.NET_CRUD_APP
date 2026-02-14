using AutoMapper;
using MediatR;
using UserManagement.Data;
using UserManagement.DTO;
using UserManagement.Models;

namespace UserManagement.Features.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // 1. Creer entite metier :
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age,
                CreatedAt = DateTime.UtcNow,
            };

            // 2. Persister en base :
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            // 3. Mapper vers UserDto
            return _mapper.Map<UserDto>(user);
        }
    }
}
