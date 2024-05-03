using RateAucProfessors.Models;

namespace RateAucProfessors.DTO.Requests
{
    public class AssignmentInfo
    {
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
    }
}
