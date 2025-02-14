using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Queries.Movies
{
    public class GetMovieByUserIdQuery : IRequest<MovieDto>
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        public GetMovieByUserIdQuery(Guid userId, Guid movieId)
        {
            UserId = userId;
            MovieId = movieId;
        }
    }

}
