using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Movie
    {

        public Guid Id { get; set; }

        public string Title { get; set; } =string.Empty;

        public DateTime WatchDate { get; set; }

        public string DirectorName { get; set; }  =string.Empty;

        public int Rating { get; set; }

        public string? Comment { get; set; }



        // User Ilışkisi
        public Guid UserId { get; set; }  // foreign key
        public User User { get; set; } =null!; // navigasyon özelliği


    }
}
