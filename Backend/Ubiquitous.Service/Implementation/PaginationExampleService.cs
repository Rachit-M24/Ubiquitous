using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ubiquitous.Data.Pagination;
using Ubiquitous.Data.Model.DTO.PaginationDto;

namespace Ubiquitous.Service.Implementation
{
    /// <summary>
    /// Example service demonstrating pagination usage with logging.
    /// </summary>
    public sealed class PaginationExampleService
    {
        private readonly ILogger<PaginationExampleService> _logger;

        public PaginationExampleService(ILogger<PaginationExampleService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets paginated items from a source query.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="query">IQueryable query.</param>
        /// <param name="pageNumber">1-based page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="userId">User identifier for logging.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Paginated result with metadata.</returns>
        public async Task<PaginationResult<T>> GetPaginatedAsync<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize,
            string userId,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(
                "Requesting paginated data. PageNumber: {PageNumber}, PageSize: {PageSize}, UserId: {UserId}",
                pageNumber,
                pageSize,
                userId);

            var result = await query.ToPaginatedAsync(pageNumber, pageSize, cancellationToken);

            _logger.LogInformation(
                "Paginated data retrieved. TotalCount: {TotalCount}, TotalPages: {TotalPages}, CurrentPageItems: {CurrentPageItems}, UserId: {UserId}",
                result.TotalCount,
                result.TotalPages,
                result.Items.Count,
                userId);

            return result;
        }

        /// <summary>
        /// Gets paginated items and maps to response DTO.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <typeparam name="TDto">DTO type.</typeparam>
        /// <param name="query">IQueryable query.</param>
        /// <param name="pageNumber">1-based page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="mapper">Mapping function from entity to DTO.</param>
        /// <param name="userId">User identifier for logging.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Paginated response DTO.</returns>
        public async Task<PaginationResponseDto<TDto>> GetPaginatedAsync<TEntity, TDto>(
            IQueryable<TEntity> query,
            int pageNumber,
            int pageSize,
            Func<TEntity, TDto> mapper,
            string userId,
            CancellationToken cancellationToken = default)
        {
            var result = await GetPaginatedAsync(query, pageNumber, pageSize, userId, cancellationToken);
            return result.ToResponseDto(mapper);
        }
    }
}
