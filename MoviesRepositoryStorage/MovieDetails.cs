using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepositoryStorage
{
    public class MovieDetails
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public int YearOfRelease { get; set; }
    }
}
