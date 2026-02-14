using MediatR;

namespace UserManagement.Features.Commands.Update
{
    public record UpdateUserCommand
    (
        string FirstName,
        string LastName,
        string Email,
        int Age
    ) : IRequest<Unit>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid Id { get; set; }
    }
}
