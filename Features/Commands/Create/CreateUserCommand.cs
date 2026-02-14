using MediatR;
using UserManagement.DTO;

namespace UserManagement.Features.Commands.Create
{

    public record CreateUserCommand
    (
      string FirstName,
      string LastName,
      string Email,
      int Age
    ) : IRequest<UserDto>;
}
