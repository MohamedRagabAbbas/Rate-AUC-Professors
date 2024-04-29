using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class ReactionInfo
    {
        public bool IsLike { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int FeedId { get; set; }
        public int CommentId { get; set; }
        public int ReplyId { get; set; }
        public int ReviewId { get; set; }
        
    }
}
