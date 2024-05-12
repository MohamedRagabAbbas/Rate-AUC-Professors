using RateAucProfessors.DTO.Response;
using RateAucProfessors.Models;

namespace RateAucProfessors.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Professor> Professor { get; }
        IGenericRepository<Student> Student { get; }
        IGenericRepository<Department> Department { get; }
        IGenericRepository<Course> Course { get; }
        IGenericRepository<Major> Major { get; }

        //IGenericRepository<Assignment> Assignment { get; }
        //IGenericRepository<Lecture> Lecture { get; }
        //IGenericRepository<Note> Note { get; }
        //IGenericRepository<Syllabus> Syllabus { get; }
        IGenericRepository<Feed> Feed { get; }
        IGenericRepository<Comment> Comment { get; }
        IGenericRepository<Reply> Reply { get; }
        IGenericRepository<Reaction> Reaction { get; }
        IGenericRepository<Review> Review { get; }
        Task<int> SaveAsync();
        // assing entity to another entity
        Task<ResponseMessage<string>> AssignEntityToEntity(Student student, Major major);

    }
}
