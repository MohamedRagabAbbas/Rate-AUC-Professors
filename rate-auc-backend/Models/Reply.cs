﻿using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        // Relationships
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public string UserId { get; set; }
        public Student? Student { get; set; }
    }
}
