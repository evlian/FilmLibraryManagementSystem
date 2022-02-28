﻿using Pixond.Data;
using Pixond.Model.General.Queries;
using MediatR;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Services.Films;
using AutoMapper;

namespace Pixond.Core.Handlers.Films.Queries.GetRandomFilm
{
    public class GetRandomFilmHandler : IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetRandomFilmHandler(IFilmsService filmsService, IMapper mapper)
        { 
            _filmsService = filmsService;
            _mapper = mapper;
        }
        public async Task<GetRandomFilmResult> Handle(GetRandomFilmQuery request, CancellationToken cancellationToken)
        {
            return new GetRandomFilmResult() 
            { 
                Film = _mapper.Map<FilmModel>(await _filmsService.GetRandomFilm(cancellationToken))
            };
        }
    }
}