using StarWars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.DAL.Repository
{
    public interface IRepository
    {
         Movie GetMovieByUrl(string url);
         IList<Movie> GetAllMovies();
    }
}
