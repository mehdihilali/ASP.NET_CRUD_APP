using MediatR;
using UserManagement.DTO;

namespace UserManagement.Features.Queries.GetById
{
    public record GetUserByIdQuery
    (
       Guid Id
    ) : IRequest<UserDto?>;
}
