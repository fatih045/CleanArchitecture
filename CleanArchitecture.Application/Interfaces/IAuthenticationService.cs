using CleanArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> AuthenticateUser(string email, string password);
    }
}
