namespace RateAucProfessors.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Syllabus { get; set; } = string.Empty;  // it should be file --> latter 
    }
}
