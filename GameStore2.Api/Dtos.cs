using System.ComponentModel.DataAnnotations;

namespace GameStore2.Api.Dtos;

public record GameDto
(
    int id,
    string name,
    string genre,
    decimal price,
    DateTime releaseDate,
    string ImageUri
);

public record CreateGameDto
(
    [Required][StringLength(50)] string name,
    [Required][StringLength(20)] string genre,
    [Range(1, 100)] decimal price,
    DateTime releaseDate,
    [Url][StringLength(100)] string ImageUri
);

public record UpdateGameDto
(
    [Required][StringLength(50)] string name,
    [Required][StringLength(20)] string genre,
    [Range(1, 100)] decimal price,
    DateTime releaseDate,
    [Url][StringLength(100)] string ImageUri
);