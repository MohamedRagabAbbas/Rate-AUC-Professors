using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class CommentInfo
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int FeedId { get; set; }
        public int ReviewId { get; set; }
    }
}
