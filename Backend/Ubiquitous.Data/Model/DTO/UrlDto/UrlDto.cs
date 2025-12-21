using System;

namespace Ubiquitous.Data.Model.DTO.UrlDto
{
    /// <summary>
    /// Data Transfer Object for URL entity.
    /// </summary>
    public class UrlDto
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the original URL.
        /// </summary>
        public string OriginalUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short code.
        /// </summary>
        public string? ShortCode { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }
    }
}
