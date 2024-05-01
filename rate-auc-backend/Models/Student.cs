using Microsoft.AspNetCore.Identity;

namespace RateAucProfessors.Models
{
    public class Student : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Student_Id { get; set; } = string.Empty;
        public bool Gender { get; set; } = true;      
        public string Standing { get; set; } = string.Empty;
        public string GraduationYear { get; set; } = string.Empty;
        // make a color picker for the user and make it one of the following randomly and user will not have the same color ["#6171BA", "#218B8B", "#EF8CCB", "#31B0CD", "#A083C9"]
        public string? Color { get; set; } = "#6171BA";



        // Relationship
        public ICollection<Feed>? Feeds { get; set; }
        public ICollection<Major>? Majors { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Reply>? Replys { get; set; }
        public ICollection<Comment>? Comments { get; set; }



    }



}
