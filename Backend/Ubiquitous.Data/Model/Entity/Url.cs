using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubiquitous.Data.Models.Entity
{
    /// <summary>
    /// Represents a URL entity with its original and shortened forms.
    /// </summary>
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(2048)]
        public string OriginalUrl { get; set; }
        [MaxLength(50)]
        public string? ShortCode { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; } = string.Empty;
        public int UserId { get; set; }
        public Users User { get; set; }
        public ICollection<ClickLog>? ClickLogs { get; set; }
    }
}