using CleanArchitecture.Application.Commands.Users;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers.Users
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {


            return await _authenticationService.RegisterAsync(new RegisterRequestDto
            {
                UserName = request.Username,
                Email = request.Email,
                Password = request.Password
            });



        }
    } 

}


