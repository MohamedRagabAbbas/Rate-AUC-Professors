namespace RateAucProfessors.Models
{
    public class StudentMajor
    {
        public string StudentId { get; set; } = string.Empty;
        public Student? Student { get; set; }
        public int MajorId { get; set; }
        public Major? Major { get; set; }
    }
}
