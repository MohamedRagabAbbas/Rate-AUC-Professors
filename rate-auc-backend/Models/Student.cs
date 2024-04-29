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
