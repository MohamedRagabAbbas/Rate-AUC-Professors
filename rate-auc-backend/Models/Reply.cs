namespace RateAucProfessors.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
