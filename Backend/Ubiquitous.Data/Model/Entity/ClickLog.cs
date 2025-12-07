using System.ComponentModel.DataAnnotations;

namespace Ubiquitous.Data.Models.Entity
{
    /// <summary>
    /// Represents a log entry for a click event on a shortened URL.
    /// </summary>
    public class ClickLog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "UrlId is required.")]
        public int UrlId { get; set; }
        public Url Url { get; set; }
        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(45, ErrorMessage = "IP address length exceeds limit.")]
        public string? ClickedByIp { get; set; }

        [MaxLength(512, ErrorMessage = "User agent length exceeds limit.")]
        public string? UserAgent { get; set; }
    }
}