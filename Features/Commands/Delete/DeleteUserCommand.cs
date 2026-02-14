using MediatR;

namespace UserManagement.Features.Commands.Delete
{
    public record DeleteUserCommand
    (
        Guid Id
    ) : IRequest<Unit>;
}
