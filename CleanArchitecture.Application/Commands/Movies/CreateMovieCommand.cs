using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Movies
{
    public class CreateMovieCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public DateTime WatchDate { get; set; }
        public string DirectorName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid UserId { get; set; } // Kullanıcı ID'si, hangi kullanıcının filmi eklediğini bilmek için



    }
}
