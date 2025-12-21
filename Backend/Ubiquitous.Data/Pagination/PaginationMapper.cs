using System.Linq;
using Ubiquitous.Data.Model.DTO.PaginationDto;

namespace Ubiquitous.Data.Pagination
{
    /// <summary>
    /// Helper to map PaginationResult to PaginationResponseDto.
    /// </summary>
    public static class PaginationMapper
    {
        /// <summary>
        /// Converts a PaginationResult to a PaginationResponseDto.
        /// </summary>
        /// <typeparam name="TSource">Source item type.</typeparam>
        /// <typeparam name="TDestination">Destination item type.</typeparam>
        /// <param name="source">Source pagination result.</param>
        /// <param name="mapper">Mapping function from source to destination.</param>
        /// <returns>Mapped PaginationResponseDto.</returns>
        public static PaginationResponseDto<TDestination> ToResponseDto<TSource, TDestination>(
            this PaginationResult<TSource> source,
            System.Func<TSource, TDestination> mapper)
        {
            return new PaginationResponseDto<TDestination>
            {
                Items = source.Items.Select(mapper).ToList(),
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                TotalPages = source.TotalPages,
                HasPreviousPage = source.HasPreviousPage,
                HasNextPage = source.HasNextPage
            };
        }

        /// <summary>
        /// Converts a PaginationResult to a PaginationResponseDto without mapping.
        /// Use when source and destination types are the same.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="source">Source pagination result.</param>
        /// <returns>Mapped PaginationResponseDto.</returns>
        public static PaginationResponseDto<T> ToResponseDto<T>(this PaginationResult<T> source)
        {
            return new PaginationResponseDto<T>
            {
                Items = source.Items,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                TotalPages = source.TotalPages,
                HasPreviousPage = source.HasPreviousPage,
                HasNextPage = source.HasNextPage
            };
        }
    }
}
