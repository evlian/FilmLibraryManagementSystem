﻿using AutoMapper;
using FilmLibraryManagementSystem.Core.Abstraction.Services.Genres;
using FilmLibraryManagementSystem.Model.General.Queries.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Genres.Queries.GetAllGenres
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, GetAllGenresResult>
    {
        private readonly IGenresService _service;
        private readonly IMapper _mapper;

        public GetAllGenresHandler(IGenresService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetAllGenresResult> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return new GetAllGenresResult() { Genres = await _service.GetAllGenres(request, cancellationToken) };
        }
    }
}
