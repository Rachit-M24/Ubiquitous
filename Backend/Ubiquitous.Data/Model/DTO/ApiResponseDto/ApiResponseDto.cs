namespace Ubiquitous.Data.Model.DTO.ApiResponseDto
{
    /// <summary>
    /// Generic API response model.
    /// </summary>
    public class ApiResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Content { get; set; }
    }
}