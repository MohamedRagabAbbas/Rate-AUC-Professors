namespace RateAucProfessors.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Document_type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public string DocumentUrl { get; set; } = string.Empty;

        //relationships
        public string UserId { get; set; }
        public Student? Student { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
