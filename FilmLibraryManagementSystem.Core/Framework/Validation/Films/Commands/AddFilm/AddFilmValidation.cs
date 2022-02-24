using FilmLibraryManagementSystem.Model.General.Commands;
using FluentValidation;

namespace FilmLibraryManagementSystem.Core.Framework.Validation.Films.Commands.AddFilm
{
    public class AddFilmValidation : AbstractValidator<AddFilmCommand>
    {
        public AddFilmValidation()
        { 
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Film Tite cannot be empty!");

            RuleFor(x => x.Director)
                .NotEmpty()
                .WithMessage("Director cannot be empty!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description cannot be empty!");
  
        }
    }
}
