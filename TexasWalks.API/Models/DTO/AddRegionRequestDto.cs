using System.ComponentModel.DataAnnotations;

namespace TexasWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code Max length is 3 character")]
        [MinLength(3, ErrorMessage = "Code Min length is 10 character")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name Max length is 100 character")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
