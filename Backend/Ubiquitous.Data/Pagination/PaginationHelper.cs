using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ubiquitous.Data.Pagination
{
    /// <summary>
    /// Generic pagination helper for server-side IQueryable-based pagination.
    /// </summary>
    public static class PaginationHelper
    {
        /// <summary>
        /// Applies pagination to an IQueryable source.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="source">IQueryable source to paginate.</param>
        /// <param name="pageNumber">1-based page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>Paginated IQueryable.</returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            ValidatePageParams(pageNumber, pageSize);

            var skip = (pageNumber - 1) * pageSize;
            return source.Skip(skip).Take(pageSize);
        }

        /// <summary>
        /// Applies pagination and returns paginated result with metadata asynchronously.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="source">IQueryable source to paginate.</param>
        /// <param name="pageNumber">1-based page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>PaginationResult with items and metadata.</returns>
        public static async Task<PaginationResult<T>> ToPaginatedAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            ValidatePageParams(pageNumber, pageSize);

            var totalCount = await source.CountAsync(cancellationToken);
            var items = await source.Paginate(pageNumber, pageSize).ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginationResult<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                HasPreviousPage = pageNumber > 1,
                HasNextPage = pageNumber < totalPages
            };
        }

        /// <summary>
        /// Applies pagination and returns paginated result with metadata synchronously.
        /// Use ToPaginatedAsync for better performance in async contexts.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="source">IQueryable source to paginate.</param>
        /// <param name="pageNumber">1-based page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>PaginationResult with items and metadata.</returns>
        public static PaginationResult<T> ToPaginated<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            ValidatePageParams(pageNumber, pageSize);

            var totalCount = source.Count();
            var items = source.Paginate(pageNumber, pageSize).ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PaginationResult<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                HasPreviousPage = pageNumber > 1,
                HasNextPage = pageNumber < totalPages
            };
        }

        private static void ValidatePageParams(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentException("Page number must be at least 1.", nameof(pageNumber));
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be at least 1.", nameof(pageSize));
            }

            if (pageSize > 1000)
            {
                throw new ArgumentException("Page size cannot exceed 1000.", nameof(pageSize));
            }
        }
    }
}
