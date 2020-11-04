using Microsoft.AspNetCore.Mvc;

using System;
using AuctionManagement.Application.Contract;
using Framework.Application;

namespace AuctionManagement.Gateways.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController: ControllerBase
    {
        //dotnet add package EventStore.Client --version 5.0.9
        private readonly ICommandDispatcher _commandDispatcher;

        public AuctionsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OpenAuctionCommand command )
        {
            _commandDispatcher.Dispatch<OpenAuctionCommand>(command);
            return Ok();
        }
        [HttpPost("{id/bids}")]
        public IActionResult Post(long id, PlaceBidCommand command)
        {
            command.AuctionId = id;
            _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
