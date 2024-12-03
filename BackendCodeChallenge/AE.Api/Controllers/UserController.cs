using AE.Application.Features.User.Commands.CreateUser;
using AE.Application.Features.User.Commands.UpdateAssignedShips;
using AE.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return users;
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateUserCommand userCommand)
        {
            var res = await _mediator.Send(userCommand);
            return CreatedAtAction(nameof(Post), new { id = res });
        }

        // PUT api/<UserController>/UpdateShips/
        [HttpPut]
        [Route("UpdateShips")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateShips(UpdateAssignedShipsCommand assignedShipsCommand)
        {
            await _mediator.Send(assignedShipsCommand);
            return AcceptedAtAction(nameof(UpdateShips), assignedShipsCommand);
        }
    }
}
