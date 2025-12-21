using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ubiquitous.Data.Pagination;
using Ubiquitous.Data.Model.DTO.ApiResponseDto;
using Ubiquitous.Data.Model.DTO.PaginationDto;
using Ubiquitous.Service.Implementation;

namespace Ubiquitous.Api.Examples
{
    /// <summary>
    /// Example controller demonstrating pagination usage.
    /// This is a reference implementation - adapt to your actual controllers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaginationExampleController : ControllerBase
    {
        private readonly PaginationExampleService _service;

        public PaginationExampleController(PaginationExampleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Example 1: Simple pagination without mapping.
        /// </summary>
        [HttpGet("simple")]
        public async Task<ActionResult<ApiResponseDto<PaginationResponseDto<object>>>> GetSimplePaginated(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Example: Assuming you have a DbContext with entities
                // var query = _dbContext.MyEntities.AsQueryable();
                // var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                // var result = await _service.GetPaginatedAsync(query, pageNumber, pageSize, userId, cancellationToken);
                // var response = result.ToResponseDto();

                return Ok(new ApiResponseDto<object>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Content = null // Replace with actual paginated response
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponseDto<object>
                {
                    StatusCode = 400,
                    Message = "Error.ValidationFailed",
                    Content = null
                });
            }
        }

        /// <summary>
        /// Example 2: Pagination with DTO mapping.
        /// </summary>
        [HttpGet("mapped")]
        public async Task<ActionResult<ApiResponseDto<PaginationResponseDto<object>>>> GetMappedPaginated(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Example: With DTO mapping
                // var query = _dbContext.MyEntities.AsQueryable();
                // var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                // var response = await _service.GetPaginatedAsync(
                //     query,
                //     pageNumber,
                //     pageSize,
                //     entity => new MyEntityDto { Id = entity.Id, Name = entity.Name },
                //     userId,
                //     cancellationToken);

                return Ok(new ApiResponseDto<object>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Content = null // Replace with actual paginated response
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponseDto<object>
                {
                    StatusCode = 400,
                    Message = "Error.ValidationFailed",
                    Content = null
                });
            }
        }

        /// <summary>
        /// Example 3: Manual pagination with filtering.
        /// </summary>
        [HttpGet("filtered")]
        public async Task<ActionResult<ApiResponseDto<PaginationResponseDto<object>>>> GetFilteredPaginated(
            [FromQuery] string searchTerm,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Example: Manual pagination with filtering
                // var query = _dbContext.MyEntities
                //     .Where(e => e.Name.Contains(searchTerm))
                //     .OrderBy(e => e.Name)
                //     .AsQueryable();
                //
                // var result = await query.ToPaginatedAsync(pageNumber, pageSize, cancellationToken);
                // var response = result.ToResponseDto();

                return Ok(new ApiResponseDto<object>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Content = null // Replace with actual paginated response
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponseDto<object>
                {
                    StatusCode = 400,
                    Message = "Error.ValidationFailed",
                    Content = null
                });
            }
        }
    }
}
