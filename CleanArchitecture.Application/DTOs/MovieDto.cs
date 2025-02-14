using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime WatchDate { get; set; }
        public string DirectorName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
