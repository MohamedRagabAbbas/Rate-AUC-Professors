using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Review
    {
        public int reply_no { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        
    }
}
