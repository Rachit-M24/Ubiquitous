namespace Ubiquitous.Data.Model.DTO
{
    /// <summary>
    /// Data Transfer Object for managing URL information.
    /// </summary>
    public class UrlManager
    {
        /// <summary>
        /// Gets or sets the unique identifier for the URL.
        /// </summary>
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