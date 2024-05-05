using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateAucProfessors.Models;
using System.Reflection.Emit;

namespace RateAucProfessors.DB
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        //public DbSet<Note> Notes { get; set; }
        //public DbSet<Lecture> Lectures { get; set; }
        //public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Document> Documents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student relationships
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Feeds)
                .WithOne(f => f.Student)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);            
            
            modelBuilder.Entity<Student>()   
                .HasMany(s => s.Replys)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Reactions)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Majors)
                .WithMany(r => r.Students)
                .UsingEntity(j => j.ToTable("StudentMajors"));

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Documents)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
            
            //modelBuilder.Entity<Student>()
            //    .HasMany(s => s.Syllabuses)
            //    .WithOne(s => s.Student)
            //    .HasForeignKey(s => s.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Student>()
            //    .HasMany(s => s.Notes)
            //    .WithOne(n => n.Student)
            //    .HasForeignKey(n => n.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Student>()
            //    .HasMany(s => s.Lectures)
            //    .WithOne(l => l.Student)
            //    .HasForeignKey(l => l.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Student>()
            //    .HasMany(s => s.Assignments)
            //    .WithOne(a => a.Student)
            //    .HasForeignKey(a => a.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);



            // Professor relationships
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Professors)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            //you will delete department but what about professors? deal with them first
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Courses)
                .WithMany(c => c.Professors)
                .UsingEntity(j => j.ToTable("CourseProfessors"));
        
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Professor)
                .HasForeignKey(r => r.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Documents)
                .WithOne(s => s.Professor)
                .HasForeignKey(s => s.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
            //Cascade, because why leave reviews and documents for professors not in the university
            //modelBuilder.Entity<Professor>()
            //    .HasMany(p => p.Syllabuses)
            //    .WithOne(s => s.Professor)
            //    .HasForeignKey(s => s.ProfessorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Professor>()
            //    .HasMany(p => p.Notes)
            //    .WithOne(n => n.Professor)
            //    .HasForeignKey(n => n.ProfessorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Professor>()
            //    .HasMany(p => p.Lectures)
            //    .WithOne(l => l.Professor)
            //    .HasForeignKey(l => l.ProfessorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Professor>()
            //    .HasMany(p => p.Assignments)
            //    .WithOne(a => a.Professor)
            //    .HasForeignKey(a => a.ProfessorId)
            //    .OnDelete(DeleteBehavior.NoAction);



            // Course relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

          modelBuilder.Entity<Course>()
                .HasMany(c => c.Documents)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Professors)
            //    .WithMany(p => p.Courses)
            //    .UsingEntity(j => j.ToTable("CourseProfessors"));

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Syllabuses)
            //    .WithOne(s => s.Course)
            //    .HasForeignKey(s => s.CourseId)
            //    .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Course>()
            //.HasMany(c => c.Lectures)
            //.WithOne(l => l.Course)
            //.HasForeignKey(l => l.CourseId)
            //.OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Notes)
            //    .WithOne(n => n.Course)
            //    .HasForeignKey(n => n.CourseId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Assignments)
            //    .WithOne(a => a.Course)
            //    .HasForeignKey(a => a.CourseId)
            //    .OnDelete(DeleteBehavior.NoAction);



            // Review relationships
            modelBuilder.Entity<Review>()
                .HasMany(r => r.Comments)
                .WithOne(c => c.Review)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasMany(r => r.Reactions)
                .WithOne(r => r.Review)
                .HasForeignKey(r => r.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);


            // Feed relationships
            modelBuilder.Entity<Feed>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Feed)
                .HasForeignKey(c => c.FeedId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feed>()
                .HasMany(f => f.Reactions)
                .WithOne(r => r.Feed)
                .HasForeignKey(r => r.FeedId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment relationships
            modelBuilder.Entity<Comment>()
                .HasMany(c => c.Replies)
                .WithOne(f => f.Comment)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasMany(c => c.Reactions)
                .WithOne(r => r.Comment)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
