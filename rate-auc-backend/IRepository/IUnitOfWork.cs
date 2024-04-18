using RateAucProfessors.Models;

namespace RateAucProfessors.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Professor> Professor { get; }
        IGenericRepository<Student> Student { get; }
        IGenericRepository<Department> Department { get; }
        IGenericRepository<Course> Course { get; }
        IGenericRepository<Assignment> Assignment { get; }
        IGenericRepository<Lecture> Lecture { get; }
        IGenericRepository<Note> Note { get; }
        IGenericRepository<Syllabus> Syllabus { get; }
        IGenericRepository<Feed> Feed { get; }
        IGenericRepository<Comment> Comment { get; }
        IGenericRepository<Reply> Reply { get; }
        IGenericRepository<Reaction> Reaction { get; }
        IGenericRepository<Rating> Rating { get; }
        Task<int> SaveAsync();
    }
}
