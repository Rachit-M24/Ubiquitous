using System.Collections.Generic;

namespace Ubiquitous.Data.Pagination
{
    /// <summary>
    /// Generic pagination result containing items and metadata.
    /// </summary>
    /// <typeparam name="T">Type of items in the paginated result.</typeparam>
    public class PaginationResult<T>
    {
        /// <summary>
        /// Gets or sets the items for the current page.
        /// </summary>
        public IReadOnlyList<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets the current page number (1-based).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count of items.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage { get; set; }
    }
}
