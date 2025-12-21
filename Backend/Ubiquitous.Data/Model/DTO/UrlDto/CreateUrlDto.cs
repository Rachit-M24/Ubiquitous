using System.ComponentModel.DataAnnotations;

namespace Ubiquitous.Data.Model.DTO.UrlDto
{
    /// <summary>
    /// Data Transfer Object for creating a new URL.
    /// </summary>
    public class CreateUrlDto
    {
        /// <summary>
        /// Gets or sets the original URL to be shortened.
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string OriginalUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the optional custom short code.
        /// </summary>
        [MaxLength(50)]
        public string? ShortCode { get; set; }

        /// <summary>
        /// Gets or sets the optional category.
        /// </summary>
        [MaxLength(100)]
        public string? Category { get; set; }
    }
}
