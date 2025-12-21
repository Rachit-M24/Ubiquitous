using System.Collections.Generic;

namespace Ubiquitous.Data.Model.DTO.PaginationDto
{
    /// <summary>
    /// Paginated response DTO for API responses.
    /// </summary>
    /// <typeparam name="T">Type of items in the paginated response.</typeparam>
    public class PaginationResponseDto<T>
    {
        /// <summary>
        /// Gets or sets the current page items.
        /// </summary>
        public IReadOnlyList<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets the current page number (1-based).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count of items across all pages.
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
