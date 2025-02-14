using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Kullanıcıları ve Filmleri temsil eden DbSet'ler
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkiler ve veritabanı yapılandırmaları burada yapılabilir.
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

       
    }
}
