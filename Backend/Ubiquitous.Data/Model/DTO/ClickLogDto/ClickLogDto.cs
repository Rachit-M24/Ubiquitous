using System;

namespace Ubiquitous.Data.Model.DTO.ClickLogDto
{
    /// <summary>
    /// Data Transfer Object for click log entity.
    /// </summary>
    public class ClickLogDto
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the URL identifier.
        /// </summary>
        public int UrlId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the click.
        /// </summary>
        public DateTime ClickedAt { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the visitor.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the user agent string.
        /// </summary>
        public string? UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the referrer URL.
        /// </summary>
        public string? Referrer { get; set; }
    }
}
