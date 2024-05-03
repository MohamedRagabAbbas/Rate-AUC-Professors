using RateAucProfessors.Models;

namespace RateAucProfessors.DTO.Requests
{
    public class DocumentInfo
    {
        public string Document_type { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public string DocumentUrl { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
    }
}
