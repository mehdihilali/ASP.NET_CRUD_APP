using MediatR;
using UserManagement.DTO;

namespace UserManagement.Features.Queries.GetAll
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;
}
