using Pixond.Model.General.Queries;
using FluentValidation;

namespace Pixond.Core.Framework.Validation.Films.Queries
{
    public class GetFilmByIdValidation : AbstractValidator<GetFilmByIdQuery>
    {
        public GetFilmByIdValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id cannot be 0 or less than 0!");
        }

    }
}
