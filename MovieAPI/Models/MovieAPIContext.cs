using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models
{
    public class MovieAPIContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        

        public MovieAPIContext(DbContextOptions<MovieAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Movie>()
              .HasData(
                  new Movie { MovieId = 1, Name = "Con Air", Genre = "Action", Director = "Simon West", Year = 1997, Rating = 7.0 },
                    new Movie { MovieId = 2, Name = "Gone in 60 Seconds", Genre = "Action", Director = "Dominic Sena", Year = 2000, Rating = 6.7 },
                    new Movie { MovieId = 3, Name = "Skyfall", Genre = "Action", Director = "Sam Mendes", Year = 2012, Rating = 7.7 },
                    new Movie { MovieId = 4, Name = "1917", Genre = "Drama", Director = "Sam Mendes", Year = 2020, Rating = 7.8 },
                    new Movie { MovieId = 5, Name = "The Rock", Genre = "Action", Director = "Michael Bay", Year = 1996, Rating = 7.5 },
                    new Movie { MovieId = 6, Name = "Remember The Titans", Genre = "Drama", Director = "Boaz Yakin", Year = 2000, Rating = 8.0 },
                    new Movie { MovieId = 7, Name = "The Big Sick", Genre = "Romantic Comedy", Director = "Michael Showalter", Year = 2017, Rating = 7.7 },
                    new Movie { MovieId = 8, Name = "The Big Short", Genre = "Drama", Director = "Adam McKay", Year = 2015, Rating = 8.0 },
                    new Movie { MovieId = 9, Name = "Den of Thieves", Genre = "Action", Director = "Christian Gudegast", Year = 2018, Rating = 7.0 },
                    new Movie { MovieId = 10, Name = "Fast Five", Genre = "Action", Director = "Justin Lin", Year = 2011, Rating = 7.5 }
                    

              );
            builder.Entity<Actor>()
                .HasData(
                    new Actor { ActorId = 1, Name = "Nicolas Cage", Age = 57, OscarWinner = true, MovieId = 1},
                    new Actor { ActorId = 2, Name = "John Malkovich", Age = 67, OscarWinner = true, MovieId = 1},
                    //Second actor in movie is Nicolas Cage, Line 34.
                    new Actor { ActorId = 3, Name = "Angelina Jolie", Age = 46, OscarWinner = true, MovieId = 2},
                    new Actor { ActorId = 4, Name = "Daniel Craig", Age = 53, OscarWinner = true, MovieId = 3},
                    new Actor { ActorId = 5, Name = "Judi Dench", Age = 86, OscarWinner = true, MovieId = 3},

                    new Actor { ActorId = 6, Name = "Sean Connery", Age = 90, OscarWinner = true, MovieId = 5},
                    new Actor { ActorId = 7, Name = "Ed Harris", Age = 70, OscarWinner = true, MovieId = 5},

                    new Actor { ActorId = 8, Name = "Denzel Washington", Age = 66, OscarWinner = true, MovieId = 6},
                    new Actor { ActorId = 9, Name = "Ryan Hurst", Age = 48, OscarWinner = true, MovieId = 6},
                    
                    new Actor { ActorId = 10, Name = "Kumail Nanjiani", Age = 43, OscarWinner = false, MovieId = 7},
                    new Actor { ActorId = 11, Name = "Zoe Kazan", Age = 31, OscarWinner = true, MovieId = 7},
                    
                    new Actor { ActorId = 12, Name = "Steve Carell", Age = 58, OscarWinner = true, MovieId = 8},
                    new Actor { ActorId = 13, Name = "Ryan Gosling", Age = 40, OscarWinner = true, MovieId = 8},
                    
                    new Actor { ActorId = 14, Name = "Gerard Butler", Age = 51, OscarWinner = false, MovieId = 9},
                    new Actor { ActorId = 15, Name = "Pablo Schreiber", Age = 43, OscarWinner = false, MovieId = 9},
                    
                    new Actor { ActorId = 16, Name = "Vin Diesel", Age = 53, OscarWinner = false, MovieId = 10},
                    new Actor { ActorId = 17, Name = "Paul Walker", Age = 40, OscarWinner = false, MovieId = 10}
                );
        }
    }
}