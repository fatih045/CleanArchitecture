using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Users
{
    public class RegisterCommand : IRequest<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }


    
    public RegisterCommand(string email, string password, string fullName)
        {
            Email = email;
            Password = password;
            Username = fullName;   
        }
    } }
