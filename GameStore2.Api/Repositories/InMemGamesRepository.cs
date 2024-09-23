using GameStore2.Api.Entities;
namespace GameStore2.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
    {
        new Game()
        {
            id = 1,
            name = "street fighter 2",
            genre = "fighting",
            price = 19.99M,
            releaseDate = new DateTime(1991,2,1),
            ImageUri = "https://placehold.co/100"
        },
            new Game()
        {
            id = 2,
            name = "Final Fantasy XIV",
            genre = "RPG",
            price = 59.99M,
            releaseDate = new DateTime(2010,9,30),
            ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
            id = 3,
            name = "FiFA 23",
            genre = "ports",
            price = 69.99M,
            releaseDate = new DateTime(2022,9,27),
            ImageUri = "https://placehold.co/100"
        }
    };

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await Task.FromResult(games.Find(game => game.id == id));
    }

    public async Task CreateAsync(Game game)
    {
        game.id = games.Max(game => game.id) + 1;
        games.Add(game);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.id == updatedGame.id);
        games[index] = updatedGame;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.id == id);
        games.RemoveAt(index);

        await Task.CompletedTask;
    }
}