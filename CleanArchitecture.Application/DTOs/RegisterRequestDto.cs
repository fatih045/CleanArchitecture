using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class RegisterRequestDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
