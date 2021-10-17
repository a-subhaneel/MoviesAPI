using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Actors> actorsContext { get; set; }
        public virtual DbSet<Movies> moviesContext { get; set; }
        public virtual DbSet<Producers> producerContext { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password;Database=MovieAPIContext").EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>().HasData(
                new Actors
                {
                    Id = 1,
                    ActorName = "Tom Hanks",
                },
                new Actors
                {
                    Id = 2,
                    ActorName = "Johnny Depp"
                },
                new Actors
                {
                    Id = 3,
                    ActorName = "Morgan Freeman"
                },
                new Actors
                {
                    Id = 4,
                    ActorName = "Clancy Brown"
                },
                new Actors
                {
                    Id = 5,
                    ActorName = "Mark Ruffalo"
                },
                new Actors
                {
                    Id = 6,
                    ActorName = "Jim Carrey"
                }
                );

            modelBuilder.Entity<Producers>().HasData(
                new Producers
                {
                    Id = 1,
                    ProducerName = "David Heyman",
                },
                new Producers
                {
                    Id = 2,
                    ProducerName = "Quentin Tarantino"
                },
                new Producers
                {
                    Id = 3,
                    ProducerName = "Niki Marvin"
                },
                new Producers
                {
                    Id = 4,
                    ProducerName = "Boaz Yakin"
                }
                );

            modelBuilder.Entity<Movies>().HasData(
                new Movies
                {
                    Id = 1,
                    MovieName = "The Shawshank Redemption",
                    ReleaseDate = "1994-09-22",
                    MovieBio = "In 1947 Portland, Maine, banker Andy Dufresne is convicted of murdering his wife and" +
                    " her lover and is sentenced to two consecutive life sentences at the Shawshank State Prison.",
                    Actors = new string[]{ "3", "4" },
                    Producer = "3"
                },
                new Movies
                {
                    Id = 2,
                    MovieName = "Now You See Me",
                    ReleaseDate = "2013-05-31",
                    MovieBio = "Now You See Me is a 2013 American heist thriller film directed by Louis Leterrier from a screenplay by Ed Solomon, Boaz Yakin, and Edward Ricourt and a story by Yakin and Ricourt. " +
                    "It is the first installment in the Now You See Me series. The film features an ensemble cast of Jesse Eisenberg, Mark Ruffalo," +
                    " Woody Harrelson, Isla Fisher, Dave Franco, Mélanie Laurent, Michael Caine, and Morgan Freeman. ",
                    Actors = new string[] { "3", "5" },
                    Producer = "4"
                },
                new Movies
                {
                    Id = 3,
                    MovieName = "Max",
                    ReleaseDate = "2015-06-26",
                    MovieBio = "A military dog that helped American Marines in Afghanistan returns to the United States and is adopted by his handler's family after suffering a traumatic experience.",
                    Actors = new string[] { "3", "6" },
                    Producer = "4"
                }
                );
        }
    }
}
