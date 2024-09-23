using System.ComponentModel.DataAnnotations;

namespace GameStore2.Api.Entities;

public class Game
{
    public int id { get; set; }

    [Required]
    [StringLength(50)]
    public required string name { get; set; }

    [Required]
    [StringLength(20)]
    public required string genre { get; set; }

    [Range(1, 100)]
    public decimal price { get; set; }
    public DateTime releaseDate { get; set; }

    [Url]
    [StringLength(100)]
    public required string ImageUri { get; set; }
}