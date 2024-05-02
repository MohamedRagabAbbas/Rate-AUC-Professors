using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class LectureInfo
    {
        public string Content { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
    }
}
