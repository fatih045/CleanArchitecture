using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<bool> // Silme başarılı mı?
    {
        public Guid Id { get; set; }
    }
}
