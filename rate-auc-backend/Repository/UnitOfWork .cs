using RateAucProfessors.DB;
using RateAucProfessors.DTO.Response;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RateAucProfessors.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext  = dbContext;
            Professor   = new GenericRepository<Professor>(_dbContext);
            Student     = new GenericRepository<Student>(_dbContext);
            Department  = new GenericRepository<Department>(_dbContext);
            Course      = new GenericRepository<Course>(_dbContext);
            Major      = new GenericRepository<Major>(_dbContext);
            //Assignment  = new GenericRepository<Assignment>(_dbContext);
            //Lecture     = new GenericRepository<Lecture>(_dbContext);
            //Note        = new GenericRepository<Note>(_dbContext);
            //Syllabus    = new GenericRepository<Syllabus>(_dbContext);
            Feed        = new GenericRepository<Feed>(_dbContext);
            Comment     = new GenericRepository<Comment>(_dbContext);
            Reply       = new GenericRepository<Reply>(_dbContext);
            Reaction    = new GenericRepository<Reaction>(_dbContext);
            Review = new GenericRepository<Review>(_dbContext);
        }
        public IGenericRepository<Professor> Professor { get; private set; }
        public IGenericRepository<Student> Student { get; private set;}
        public IGenericRepository<Department> Department { get; private set;}
        public IGenericRepository<Course> Course { get; private set;}
        public IGenericRepository<Major> Major { get; private set; }
        //public IGenericRepository<Assignment> Assignment { get; private set;}
        //public IGenericRepository<Lecture> Lecture { get; private set;}
        //public IGenericRepository<Note> Note { get; private set;}
        //public IGenericRepository<Syllabus> Syllabus { get; private set;}
        public IGenericRepository<Feed> Feed { get; private set;}
        public IGenericRepository<Comment> Comment { get; private set;}
        public IGenericRepository<Reply> Reply { get; private set;}
        public IGenericRepository<Reaction> Reaction { get; private set;}
        public IGenericRepository<Review> Review { get; private set;}

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<ResponseMessage<string>> AssignEntityToEntity(Student student, Major major)
        {
            student.Majors?.Add(major);
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
            return new ResponseMessage<string>()
            {
                Message = "The student is successfully assigned to the major...",
                Status = true,
                Data = "The student is successfully assigned to the major..."
            };
        }
    }
}
