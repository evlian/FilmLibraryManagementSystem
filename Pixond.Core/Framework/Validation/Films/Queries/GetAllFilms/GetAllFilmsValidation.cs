using Pixond.Model.General.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixond.Core.Framework.Validation.Films.Queries.GetAllFilms
{
    public class GetAllFilmsValidation : AbstractValidator<GetAllFilmsQuery>
    {
        public GetAllFilmsValidation() 
        { 
            
        }
    }
}
