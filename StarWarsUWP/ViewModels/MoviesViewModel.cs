using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.DAL.Repository.Api;
using StarWars.Domain;

namespace StarWarsUWP.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                RaisePropertyChanged("Movies");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MoviesViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            ApiRepository Repo = new ApiRepository();
            IList<Movie> movieList = Repo.GetAllMovies();
            ObservableCollection<Movie> movieListCollection = new ObservableCollection<Movie>();
            foreach (var movie in movieList)
            {
                movie.ImagePath = String.Format("Assets/Posters/{0}.jpg", movie.Title.Replace(" ", "_").ToLower());
                movieListCollection.Add(movie);
            }

            Movies = movieListCollection;
            _selectedMovie = getMovies().First();
        }

        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
                
            }
            set
            {
                _selectedMovie = value;
                RaisePropertyChanged("SelectedMovie");
            }
        }


        public ObservableCollection<Movie> getMovies()
        {
            return _movies;
        }

        public void addMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void setMovies(ObservableCollection<Movie> movies)
        {
            this._movies = movies;
            RaisePropertyChanged("Movies");
        }
    }
}
