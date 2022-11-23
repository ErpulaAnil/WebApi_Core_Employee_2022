using MinimalJwt.Models;

namespace MinimalJwt.Repositories
{
    public class MovieRepository
    {
        public static List<Movie> Movies = new()
        {
            new()
            {
              Id=1,Title="RRR",Description="History of legends",Rating=9.0
            },

            new()
            {
                Id = 2,Title = "KGF2",Description = "Mother Sentiment Movie", Rating = 8.0
            },
            new()
            {
                Id = 3,Title = "Bahubali", Description = "Historical Movie", Rating = 8.1
            },
            new()
            {
                Id = 4, Title = "Avatar",Description = "Adventure Movie",Rating = 9.5
            },
            new()
            {
                Id = 5,Title = "Titanic",Description = "Lovestory Movie",Rating = 9.5
            },
        };
    }
}
