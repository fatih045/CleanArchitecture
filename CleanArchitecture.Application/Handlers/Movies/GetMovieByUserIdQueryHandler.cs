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
    public class GetMovieByUserIdQueryHandler : IRequestHandler<GetMovieByUserIdQuery, MovieDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovieByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MovieDto> Handle(GetMovieByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcının izlediği tek bir filmi ID ile getir
            var movie = await _unitOfWork.MovieRepository.GetMovieByUserIdAsync(request.UserId, request.MovieId);

            if (movie == null)
                throw new Exception("Film bulunamadı!");

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                DirectorName = movie.DirectorName,
                WatchDate = movie.WatchDate,
                Rating = movie.Rating,
                Comment = movie.Comment

            };
        }
    
    }
}
