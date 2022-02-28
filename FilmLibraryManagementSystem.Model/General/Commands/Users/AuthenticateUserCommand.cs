﻿using MediatR;
using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem.Model.General.Commands.Users
{
    public class AuthenticateUserCommand : IRequest<AuthenticateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
