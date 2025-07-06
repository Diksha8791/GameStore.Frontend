using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = new List<GameSummary>
    {
        new GameSummary { Id = 1, Name = "Street Fighter II", Genre = "Fighting", Price = 19.99m, ReleaseDate = new DateOnly(1992, 1, 15) },
        new GameSummary { Id = 2, Name = "Final Fanatasy XIV", Genre = "Roleplaying", Price = 49.99m, ReleaseDate = new DateOnly(2010, 2, 20) },
        new GameSummary { Id = 3, Name = "FIFA 23", Genre = "Sports", Price = 39.99m, ReleaseDate = new DateOnly(2022, 3, 10) }
    };

    public List<GameSummary> GetGames()
    {
        //[.. games];  // to go from lis tinto an array
        return games;
    }

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }
}
