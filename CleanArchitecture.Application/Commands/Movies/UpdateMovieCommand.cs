using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Movies
{
    public class UpdateMovieCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime WatchDate { get; set; }
        public string DirectorName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
