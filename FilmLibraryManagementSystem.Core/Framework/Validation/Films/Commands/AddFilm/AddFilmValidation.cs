using FilmLibraryManagementSystem.Model.General.Commands;
using FluentValidation;

namespace FilmLibraryManagementSystem.Core.Framework.Validation.Films.Commands.AddFilm
{
    public class AddFilmValidation : AbstractValidator<AddFilmCommand>
    {
        public AddFilmValidation()
        { 
            RuleFor(x => x.FilmTitle)
                .NotEmpty()
                .WithMessage("Film Tite cannot be empty!");

            RuleFor(x => x.FilmDirector)
                .NotEmpty()
                .WithMessage("Director cannot be empty!");

            RuleFor(x => x.FilmDescription)
                .NotEmpty()
                .WithMessage("Description cannot be empty!");
  
        }
    }
}
