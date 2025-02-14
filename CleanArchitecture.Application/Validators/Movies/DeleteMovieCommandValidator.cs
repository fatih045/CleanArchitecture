using CleanArchitecture.Application.Commands.Movies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Validators.Movies
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Film ID boş olamaz!");
        }
    }
}
