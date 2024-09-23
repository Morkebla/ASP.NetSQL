using GameStore2.Api.Dtos;

namespace GameStore2.Api.Entities;

public static class EntityExtensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto
        (
            game.id,
            game.name,
            game.genre,
            game.price,
            game.releaseDate,
            game.ImageUri
        );
    }
}