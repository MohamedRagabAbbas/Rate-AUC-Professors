using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class RatingInfo
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        [Range(1, 5)]
        public int Value { get; set; }
        public string Comments { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
    }
}
