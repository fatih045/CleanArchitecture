using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IMovieRepository
    {

        Task<Movie?>GetByIdAsync(Guid id); // 
        Task<List<Movie>> GetAllAsync();
        Task AddAsync(Movie movie);  //+
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Guid id);
       


        Task<Movie?> GetMovieByUserIdAsync(Guid userId, Guid movieId); //+

        // Kullanıcının izlediği tüm filmleri getir
        Task<List<Movie>> GetMoviesByUserAsync(Guid userId); //+
    }
}
