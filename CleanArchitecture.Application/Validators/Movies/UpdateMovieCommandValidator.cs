using CleanArchitecture.Application.Commands.Movies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Validators.Movies
{
    public class UpdateMovieCommandValidator  : AbstractValidator<UpdateMovieCommand>
    {

        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Id)
                       .NotEmpty().WithMessage("Film ID boş olamaz!");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Film adı boş olamaz!")
                .MaximumLength(100).WithMessage("Film adı en fazla 100 karakter olabilir!");

            RuleFor(x => x.DirectorName)
                .NotEmpty().WithMessage("Yönetmen adı boş olamaz!")
                .MaximumLength(50).WithMessage("Yönetmen adı en fazla 50 karakter olabilir!");

            RuleFor(x => x.WatchDate)
                .NotEmpty().WithMessage("İzleme tarihi boş olamaz!")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("İzleme tarihi bugünden büyük olamaz!");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 10).WithMessage("Puan 1 ile 10 arasında olmalıdır!");
        }





    }
}
