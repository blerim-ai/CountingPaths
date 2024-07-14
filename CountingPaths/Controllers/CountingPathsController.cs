using CountingPathsApi.Models;
using CountingPathsApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CountingPathsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountingPathsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountingPathsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PathResponse>> GetPaths([FromBody] CoordinateRequest request)
        {
            if (request.X < 0 || request.Y < 0 || request.X > 1000 || request.Y > 1000)
            {
                return BadRequest("X and Y must be between 0 and 1000, inclusive.");
            }

            var query = new GetPathsQueryRequest(request);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
