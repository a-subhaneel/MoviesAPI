using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private MoviesService _moviesService;
        public MoviesController(ILogger<MoviesController> logger, MoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            try
            {
                List<Movies> result = _moviesService.getAllMoviesService();
                return Ok(result);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return Ok("Failed");
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movies movieDetails) 
        {
            try
            {
                var result = _moviesService.createMovieService(movieDetails);
                return Ok("Successfully created");
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return Ok("Failed");
        }

        [HttpPost]
        public IActionResult EditMovie([FromBody] Movies movieDetails)
        {
            try
            {
                var result = _moviesService.editMovieService(movieDetails);
                return Ok("Successfully Updated");
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return Ok("Failed");
        }
    }
}
