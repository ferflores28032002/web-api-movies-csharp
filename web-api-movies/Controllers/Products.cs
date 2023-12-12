using Microsoft.AspNetCore.Mvc;
using web_api_movies.Dtos;
using web_api_movies.Models;

namespace web_api_movies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie { Id = Guid.NewGuid(), Title = "Movie 1", Genre = "Action", ReleaseYear = 2020, Director = "Director 1", Description = "Description 1" },
            new Movie { Id = Guid.NewGuid(), Title = "Movie 2", Genre = "Drama", ReleaseYear = 2019, Director = "Director 2", Description = "Description 2" },
            new Movie { Id = Guid.NewGuid(), Title = "Movie 3", Genre = "Comedy", ReleaseYear = 2021, Director = "Director 3", Description = "Description 3" }
            // Add more movies as needed
        };

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movies);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movieDto)
        {
            if (movieDto == null)
            {
                return BadRequest("Invalid movie data");
            }

            var newMovie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseYear = movieDto.ReleaseYear,
                Director = movieDto.Director,
                Description = movieDto.Description
            };

            _movies.Add(newMovie);

            // Assuming a successful creation, return a 201 Created status along with the new movie
            return CreatedAtAction(nameof(GetMovies), newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(Guid id, [FromBody] MovieDto movieDto)
        {
            var movieToUpdate = _movies.FirstOrDefault(m => m.Id == id);

            if (movieToUpdate == null)
            {
                return NotFound(); // Return 404 if the movie with the given ID is not found
            }

            // Update properties based on the provided MovieDto
            movieToUpdate.Title = movieDto.Title;
            movieToUpdate.Genre = movieDto.Genre;
            movieToUpdate.ReleaseYear = movieDto.ReleaseYear;
            movieToUpdate.Director = movieDto.Director;
            movieToUpdate.Description = movieDto.Description;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(Guid id)
        {
            var movieToRemove = _movies.FirstOrDefault(m => m.Id == id);

            if (movieToRemove == null)
            {
                return NotFound(); // Return 404 if the movie with the given ID is not found
            }

            _movies.Remove(movieToRemove);

            return Ok();
        }
    }
}
