using FilmLibraryManagementSystem.Model.General.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Framework.Validation.Films.Queries.GetAllFilms
{
    public class GetAllFilmsValidation : AbstractValidator<GetAllFilmsQuery>
    {
        public GetAllFilmsValidation() 
        { 
            
        }
    }
}
