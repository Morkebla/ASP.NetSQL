using GameStore2.Api.Dtos;
using GameStore2.Api.Entities;
using GameStore2.Api.Repositories;

namespace GameStore2.Api.EndPoints;

public static class GamesEndPoints
{
    const string getGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndPoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("", async (IGamesRepository repository) => (await repository.GetAllAsync()).Select(game => game.AsDto()));


        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        }).WithName(getGameEndPointName);

        group.MapPost("", async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                name = gameDto.name,
                genre = gameDto.genre,
                price = gameDto.price,
                releaseDate = gameDto.releaseDate,
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);
            return Results.CreatedAtRoute(getGameEndPointName, new { id = game.id }, game);
        });

        group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGame) =>
        {
            Game? existingGame = await repository.GetAsync(id);

            if (existingGame is null) { return Results.NotFound(); }
            existingGame.name = updatedGame.name;
            existingGame.genre = updatedGame.genre;
            existingGame.price = updatedGame.price;
            existingGame.releaseDate = updatedGame.releaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            await repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);

            if (game is not null) { await repository.DeleteAsync(id); }

            return Results.NoContent();
        });

        return group;
    }
}