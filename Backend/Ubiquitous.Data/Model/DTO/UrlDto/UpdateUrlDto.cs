using System.ComponentModel.DataAnnotations;

namespace Ubiquitous.Data.Model.DTO.UrlDto
{
    /// <summary>
    /// Data Transfer Object for updating an existing URL.
    /// </summary>
    public class UpdateUrlDto
    {
        /// <summary>
        /// Gets or sets the original URL.
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string OriginalUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the optional category.
        /// </summary>
        [MaxLength(100)]
        public string? Category { get; set; }
    }
}
