using CleanArchitecture.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
