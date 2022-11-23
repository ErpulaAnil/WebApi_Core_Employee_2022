using MinimalJwt.Models;
using MinimalJwt.Repositories;

namespace MinimalJwt.Services
{
    public class MovieService : IMovieService
    {
        public Movie Create(Movie movie)
        {
            movie.Id=MovieRepository.Movies.Count + 1;
            MovieRepository.Movies.Add(movie);  
            return movie;
        }

        public bool Delete(int id)
        {
           var oldmovie= MovieRepository.Movies.FirstOrDefault(x => x.Id ==id);
            if(oldmovie is null)    return false;   
            MovieRepository.Movies.Remove(oldmovie);
            return true;    
        }

        public Movie Get(int id)
        {
          var movie=MovieRepository.Movies.FirstOrDefault(x => x.Id == id);
            if (movie is null) return null;
            return movie;
                    
        }

        public List<Movie> List()
        {
            var movies=MovieRepository.Movies;
            return movies;
        }

        public Movie Update(Movie newMovie)
        {
            var oldmovie = MovieRepository.Movies.FirstOrDefault(x => x.Id == newMovie.Id);
            if(oldmovie is null) return null;

            oldmovie.Title = newMovie.Title;
            oldmovie.Description = newMovie.Description;    
            oldmovie.Rating= newMovie.Rating;

            return newMovie;
        }
    }
}
