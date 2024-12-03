using AE.Application.Features.Ship.Commands.CreateShip;
using AE.Application.Features.Ship.Commands.UpdateShipVelocity;
using AE.Application.Features.Ship.Queries.GetAllShips;
using AE.Application.Features.Ship.Queries.GetClosestPort;
using AE.Application.Features.Ship.Queries.GetShipsAssignedToUser;
using AE.Application.Features.Ship.Queries.GetShipsUnassigned;
using AE.Application.Features.Ship.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ShipController>
        [HttpGet]
        public async Task<IEnumerable<ShipDto>> Get()
        {
            var ships = await _mediator.Send(new GetAllShipsQuery());
            return ships;
        }

        // GET api/<ShipController>/AssignedShips/5
        [HttpGet("AssignedShips/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ShipDto>> AssignedShips(int userId)
        {
            var ships = await _mediator.Send(new GetShipsAssignedToUserQuery(userId));
            return ships;
        }

        // GET api/<ShipController>/UnassignedShips
        [HttpGet]
        [Route("UnassignedShips")]
        public async Task<IEnumerable<ShipDto>> GetUnassignedShips()
        {
            var ships = await _mediator.Send(new GetShipsUnassignedQuery());
            return ships;
        }

        // GET api/<ShipController>/ClosestPort/5
        [HttpGet("ClosestPort/{shipId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ClosestPortDto> ClosestPort(int shipId)
        {
            var closestPort = await _mediator.Send(new GetClosestPortQuery(shipId));
            return closestPort;
        }

        // POST api/<ShipController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateShipCommand createShipCommand)
        {
            var res = await _mediator.Send(createShipCommand);
            return CreatedAtAction(nameof(Post), new { id = res });
        }

        // PUT api/<ShipController>/UpdateVelocity
        [HttpPut]
        [Route("UpdateVelocity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateVelocity(UpdateShipVelocityCommand updateShipVelocityCommand)
        {
            await _mediator.Send(updateShipVelocityCommand);
            return AcceptedAtAction(nameof(UpdateVelocity), updateShipVelocityCommand);
        }
    }
}
