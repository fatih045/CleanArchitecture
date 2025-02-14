using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Queries.Movies
{
    public class GetMoviesByUserQuery :IRequest<List<MovieDto>>
    {
        public Guid UserId { get; set; }

        public GetMoviesByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
