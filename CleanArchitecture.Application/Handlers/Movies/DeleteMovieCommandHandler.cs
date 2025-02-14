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
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            
            var movie =await _unitOfWork.MovieRepository.GetByIdAsync(request.Id);
           if (movie == null) return false;
            
            
            await _unitOfWork.MovieRepository.DeleteAsync(movie.Id);
            await _unitOfWork.SaveChangesAsync();
            return true;


        }
    }
}
