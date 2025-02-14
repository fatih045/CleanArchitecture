using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<Guid> // Kullanıcı ID’sini döndüreceğiz
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; }=string.Empty;
    }
}
