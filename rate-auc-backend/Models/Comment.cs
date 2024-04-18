using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Comment
    {
        public int comment_no { get; set; } = 0;

        [Required]
        public string Text { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;


        // Relationships
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public ICollection<Reply>? Replies { get; set; }
    }
}
