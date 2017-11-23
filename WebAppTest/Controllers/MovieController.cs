using MoviesRepositoryStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppTest.Controllers
{
    public class MovieController : ApiController
    {
        // GET: api/Movie
        public IEnumerable<MovieDetails> Get()
        {
            return new MoviesData().GetAllMovies().OrderBy(x => x.YearOfRelease);
        }

        // GET: api/Movie/5
        public MovieDetails Get(int id)
        {
            return new MoviesData().GetMovieByID(id);
        }

        // POST: api/Movie
        public void Post([FromBody]MovieDetails value)
        {
            var success = new MoviesData().Save(value);
        }

    }
}
