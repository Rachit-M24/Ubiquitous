using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubiquitous.Data.Model.Entity
{
    /// <summary>
    /// Represents a URL entity with its original and shortened forms.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Gets or sets the unique identifier for the URL.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        /// <summary>
        /// Gets or sets the original URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the shortened version of the URL.
        /// </summary>
        public string ShortenUrl { get; set; }

        /// <summary>
        /// Gets or sets the type/category of the URL.
        /// </summary>
        public string Type { get; set; }
    }
}