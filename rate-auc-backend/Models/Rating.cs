namespace RateAucProfessors.Models
{
    public class Rating
    {
        public int Id { get; set; }
        //public int StudentID { get; set; }
        //public int ProfessorID { get; set; }
        //public int CourseID { get; set; }
        public int RatingValue { get; set; }  // from 0 to 5
        public DateTime DateRated { get; set; } = DateTime.Now;
    }
}
