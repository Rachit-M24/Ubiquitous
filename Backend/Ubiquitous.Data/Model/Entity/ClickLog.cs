using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubiquitous.Data.Model.Entity
{
    /// <summary>
    /// Represents a log entry for a click event on a shortened URL.
    /// </summary>
    public class ClickLog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the click log entry.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the associated URL.
        /// </summary>
        [Required]
        public int UrlId { get; set; }

        /// <summary>
        /// Gets or sets the associated URL entity.
        /// </summary>
        [ForeignKey("UrlId")]
        public Url Url { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the URL was clicked.
        /// </summary>
        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the IP address of the user who clicked the URL.
        /// </summary>
        public string ClickedByIp { get; set; }

        /// <summary>
        /// Gets or sets the user agent string of the client that clicked the URL.
        /// </summary>
        public string UserAgent { get; set; }
    }
}