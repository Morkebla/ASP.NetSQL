using GameStore2.Api.Data;
using GameStore2.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore2.Api.Repositories;

public class EntityFrameWorkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext dbContext;

    public EntityFrameWorkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.games.FindAsync(id);
    }

    public async Task CreateAsync(Game game)
    {
        dbContext.games.Add(game);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.games.Where(game => game.id == id).ExecuteDeleteAsync();
    }
}