using CleanArchitecture.Application.Commands.Movies;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.Movies
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(request.Id);

            if (movie == null) return false;
            
            
            movie.Title = request.Title;
            movie.WatchDate = request.WatchDate;
            movie.DirectorName = request.DirectorName;
            movie.Rating = request.Rating;
            movie.Comment = request.Comment;
            await _unitOfWork.MovieRepository.UpdateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
