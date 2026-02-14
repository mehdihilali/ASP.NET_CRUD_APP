using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DTO;
using UserManagement.Features.Commands.Create;
using UserManagement.Features.Commands.Delete;
using UserManagement.Features.Commands.Update;
using UserManagement.Features.Queries.GetAll;
using UserManagement.Features.Queries.GetById;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if (user == null)
                return NotFound(new { message = $"User with ID {id} Not found" });
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            // On lie l'ID de l'URL à la commande
            command.Id = id;

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}