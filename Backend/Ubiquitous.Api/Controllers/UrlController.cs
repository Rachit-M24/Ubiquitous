using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ubiquitous.Data.Models.Entity;
using Ubiquitous.Api.Controllers;
using Ubiquitous.Data.Model.DTO.ApiResponseDto;

namespace Ubiquitous.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : BaseController
    {
        private readonly UbiquitousDbContext _context;

        public UrlController(UbiquitousDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseDto<List<Url>>>> GetAll()
        {
            var urls = await _context.Urls.ToListAsync();
            return ApiResponse(200, "Fetched all URLs", urls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseDto<Url>>> GetById(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null)
                return ApiResponse<Url>(404, "URL not found", null);
            return ApiResponse(200, "Fetched URL", url);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseDto<Url>>> Insert([FromBody] Url url)
        {
            if (!ModelState.IsValid)
                return ApiResponse<Url>(400, "Invalid model", null);

            url.CreatedDate = DateTime.UtcNow;
            url.ModifiedDate = DateTime.UtcNow;
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
            return ApiResponse(201, "URL created", url);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponseDto<Url>>> Update(int id, [FromBody] Url updatedUrl)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null)
                return ApiResponse<Url>(404, "URL not found", null);

            url.OriginalUrl = updatedUrl.OriginalUrl;
            url.ShortCode = updatedUrl.ShortCode;
            url.Category = updatedUrl.Category;
            url.ModifiedDate = DateTime.UtcNow;
            url.ModifiedBy = updatedUrl.ModifiedBy;
            url.UserId = updatedUrl.UserId;
            await _context.SaveChangesAsync();
            return ApiResponse(200, "URL updated", url);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponseDto<Url>>> Delete(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null)
                return ApiResponse<Url>(404, "URL not found", null);

            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return ApiResponse<Url>(200, "URL deleted", null);
        }
    }
}
    