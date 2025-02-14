using CleanArchitecture.Application.Commands.Movies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.Movies
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public  async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                WatchDate = request.WatchDate,
                DirectorName = request.DirectorName,
                Rating = request.Rating,
                Comment = request.Comment,
                UserId = request.UserId


            };

            await _unitOfWork.MovieRepository.AddAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return movie.Id;
        }
    }
}
