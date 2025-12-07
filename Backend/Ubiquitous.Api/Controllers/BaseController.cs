using Microsoft.AspNetCore.Mvc;
using Ubiquitous.Data.Model.DTO.ApiResponseDto;

namespace Ubiquitous.Api.Controllers
{
    /// <summary>
    /// Base controller to provide generic response methods for API controllers.
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Sends a generic API response with status code, message, and optional content.
        /// </summary>
        /// <typeparam name="T">Type of the response content.</typeparam>
        /// <param name="statusCode">HTTP status code to return.</param>
        /// <param name="message">Message describing the response.</param>
        /// <param name="content">Optional response content.</param>
        /// <returns>ActionResult with structured response.</returns>
        protected ActionResult<ApiResponseDto<T>> ApiResponse<T>(int statusCode, string message, T? content = default)
        {
            var response = new ApiResponseDto<T>
            {
                StatusCode = statusCode,
                Message = message,
                Content = content
            };
            return StatusCode(statusCode, response);
        }
    }
}