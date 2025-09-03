using System.ComponentModel.DataAnnotations;

namespace TexasWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        public string RegionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public string LengthInKm { get; set; }
        

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

    }
}
