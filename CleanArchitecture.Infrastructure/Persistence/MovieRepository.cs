using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

       

        public async Task<Movie?> GetMovieByUserIdAsync(Guid userId, Guid movieId)
        {
            return await _context.Movies
               .FirstOrDefaultAsync(m => m.UserId == userId && m.Id == movieId);

        }

        public async Task<List<Movie>> GetMoviesByUserAsync(Guid userId)
        {
            return await _context.Movies
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }
    }
}
