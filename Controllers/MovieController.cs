using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300084.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {
            new Movie ("The Shawshank Redemption", "Frank Darabont", [ "Tim Robbins", "Morgan Freeman", "Bob Gunton" ],
                "A banker convicted of uxoricide forms a friendship over a quarter century with a " +
                "hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ),

            new Movie ("The Godfather", "Francis Ford Coppola", [ "Marlon Brando", "Al Pacino", "James Caan" ],
                "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),

            new Movie ( "The Dark Knight", "Christopher Nolan", [ "Christian Bale", "Heath Ledger", "Aaron Eckhart" ],
                "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey " +
                "Dent must work together to put an end to the madness." ),
        };
        [HttpGet]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            return Ok(movieList);
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            return Ok(movieList[id]);
        }
        [HttpPost]
        public ActionResult<Movie> AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            movieList.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movieList.Count - 1 }, movie);
        }
        /*[HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            if (movie == null)
            {
                return BadRequest();
            }
            movieList[id] = movie;
            return NoContent();
        }*/
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            movieList.RemoveAt(id);
            return NoContent();
        }
    }
}
