using Microsoft.Extensions.Logging;
using MoviesAPI.DataContext;
using MoviesAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly ILogger<MoviesService> _logger;
        private readonly DataBaseContext DBContext;

        public MoviesService(ILogger<MoviesService> logger, DataBaseContext baseContext)
        {
            _logger = logger;
            this.DBContext = baseContext;
        }

        public List<Movies> getAllMoviesService()
        {
            try
            {
                List<Movies> MoviesList = new List<Movies>();
                List<Movies> movieListDetails = DBContext.moviesContext.ToList();
                List<Actors> actors = DBContext.actorsContext.ToList();
                List<Producers> producers = DBContext.producerContext.ToList();

                MoviesList = (from data in movieListDetails
                              select data).Select(pass => new Movies()
                              {
                                  Id = pass.Id,
                                  MovieName = pass.MovieName,
                                  ReleaseDate = pass.ReleaseDate,
                                  MovieBio = pass.MovieBio,

                                  ActorList = actors.Where(x => pass.Actors.Contains(x.Id.ToString())).ToList(),
                                  ProducerList = producers.Where(x => x.Id == Convert.ToInt32(pass.Producer)).ToList()

                              }).ToList();

                return MoviesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Movies createMovieService(Movies movieDetails)
        {
            try
            {
                Movies saveMovie = new Movies();
                saveMovie.MovieName = movieDetails.MovieName;
                saveMovie.ReleaseDate = movieDetails.ReleaseDate;
                saveMovie.MovieBio = movieDetails.MovieBio;
                saveMovie.Actors = movieDetails.ActorList.Select(I => Convert.ToString(I.Id)).ToArray();
                saveMovie.Producer = movieDetails.ProducerList.Select(I => I.Id).FirstOrDefault().ToString();
                DBContext.moviesContext.Add(saveMovie);
                DBContext.SaveChanges();
                return saveMovie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Movies editMovieService(Movies movieDetails)
        {
            try
            {
                Movies saveMovie = DBContext.moviesContext.Where(x => x.Id == movieDetails.Id).FirstOrDefault();
                saveMovie.MovieName = movieDetails.MovieName;
                saveMovie.ReleaseDate = movieDetails.ReleaseDate;
                saveMovie.MovieBio = movieDetails.MovieBio;
                saveMovie.Actors = movieDetails.ActorList.Select(I => Convert.ToString(I.Id)).ToArray();
                saveMovie.Producer = movieDetails.ProducerList.Select(I => I.Id).FirstOrDefault().ToString();
                DBContext.moviesContext.Update(saveMovie);
                DBContext.SaveChanges();
                return saveMovie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
