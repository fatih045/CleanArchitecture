using CleanArchitecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository UserRepository { get; init; }
        public IMovieRepository MovieRepository { get; init; }


        public UnitOfWork(AppDbContext context, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _context = context;
            UserRepository = userRepository;
            MovieRepository = movieRepository;
        }

       





        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
