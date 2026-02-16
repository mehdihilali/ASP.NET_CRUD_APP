using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Exceptions;

namespace UserManagement.Features.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly AppDbContext _context;

        public UpdateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FindAsync(request.Id, cancellationToken);

            if (user is null)
                throw new NotFoundException("User", request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Age = request.Age;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
