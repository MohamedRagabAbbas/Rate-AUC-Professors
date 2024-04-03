namespace RateAucProfessors.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //public int FeedID { get; set; }
        public string Content { get; set; } = string.Empty;
        //public int StudentID { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
