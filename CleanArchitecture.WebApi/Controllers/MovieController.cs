using CleanArchitecture.Application.Commands.Movies;
using CleanArchitecture.Application.Queries.Movies;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{userId}/{movieId}")]
        public async Task<IActionResult> GetMovieByUserId(Guid userId, Guid movieId)
        {
            var query = new GetMovieByUserIdQuery(userId, movieId);
            var movie = await _mediator.Send(query);
            return movie != null ? Ok(movie) : NotFound();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetMoviesByUser(Guid userId)
        {
            var query = new GetMoviesByUserQuery(userId);
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var command = new DeleteMovieCommand {Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
