namespace Ubiquitous.Data.Model.DTO.PaginationDto
{
    /// <summary>
    /// Pagination parameters for requests.
    /// </summary>
    public class PaginationParams
    {
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;
        private const int MaxPageSize = 1000;

        private int _pageNumber = DefaultPageNumber;
        private int _pageSize = DefaultPageSize;

        /// <summary>
        /// Gets or sets the page number (1-based).
        /// Default: 1
        /// </summary>
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? DefaultPageNumber : value;
        }

        /// <summary>
        /// Gets or sets the page size.
        /// Default: 10, Max: 1000
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? DefaultPageSize : (value > MaxPageSize ? MaxPageSize : value);
        }
    }
}
