using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Queries.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.Movies
{
    public class GetMoviesByUserQueryHandler : IRequestHandler<GetMoviesByUserQuery, List<MovieDto>>

    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMoviesByUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovieDto>> Handle(GetMoviesByUserQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcının izlediği filmleri getir
            var movies = await _unitOfWork.MovieRepository.GetMoviesByUserAsync(request.UserId);

            // MovieDto formatına dönüştür
            return movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                DirectorName = m.DirectorName,
                WatchDate = m.WatchDate,
                Rating = m.Rating,
                Comment = m.Comment
            }).ToList();
        }
    }
}
