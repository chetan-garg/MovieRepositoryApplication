using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MoviesRepositoryStorage
{
    internal class MoviesXmlRepository : IMovieRepository
    {
        private string xmlFileName = "MoviesData.xml";

        List<MovieDetails> allDetails = new List<MovieDetails>();

        public bool Add(MovieDetails movie)
        {
            try
            {
                if (movie != null && allDetails.Find(x => x.MovieName == movie.MovieName && x.YearOfRelease == movie.YearOfRelease) != null)
                {
                    allDetails.Add(movie);
                }

                XmlSerializer xml = new XmlSerializer(typeof(MovieDetails));
                XmlWriter writer = XmlWriter.Create(xmlFileName);
                writer.WriteElementString("Movies", "");
                foreach (MovieDetails mov in allDetails)
                {
                    xml.Serialize(writer, mov);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MovieDetails> GetAll()
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFileName, LoadOptions.None);
                if (doc != null)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MovieDetails));

                    foreach (var node in doc.Nodes())
                    {
                        MovieDetails details = (MovieDetails)serializer.Deserialize(node.CreateReader(ReaderOptions.None));
                        allDetails.Add(details);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return allDetails;
        }

        public MovieDetails GetByID(int id)
        {
            if (allDetails.Count == 0)
            {
                GetAll();
            }

            return allDetails.Find(x => x.ID == id);
        }
    }
}