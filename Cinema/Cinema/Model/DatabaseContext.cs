using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Zipcode> Zipcode { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<Theater> Theater { get; set; }
        public DbSet<Seat> Seat { get; set; }

        public DbSet<MovieGenre> MovieGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dette er 1-M M-1   her er samlingstabellen
            modelBuilder.Entity<MovieGenre>()
            .HasKey(t => new { t.movieId, t.genreId });


        }
    }
}
