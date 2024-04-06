namespace RateAucProfessors.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;

        //relationships
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
