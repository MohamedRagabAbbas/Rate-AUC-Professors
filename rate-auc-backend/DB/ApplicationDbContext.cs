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
        public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student relationships
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Ratings)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Feeds)
                .WithOne(f => f.Student)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Reactions)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Syllabuses)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Notes)
                .WithOne(n => n.Student)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Lectures)
                .WithOne(l => l.Student)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Assignments)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.UserId);



            // Professor relationships
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Professors)
                .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Courses)
                .WithMany(c => c.Professors)
                .UsingEntity(j => j.ToTable("CourseProfessors"));

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Ratings)
                .WithOne(r => r.Professor)
                .HasForeignKey(r => r.ProfessorId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Syllabuses)
                .WithOne(s => s.Professor)
                .HasForeignKey(s => s.ProfessorId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Notes)
                .WithOne(n => n.Professor)
                .HasForeignKey(n => n.ProfessorId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Lectures)
                .WithOne(l => l.Professor)
                .HasForeignKey(l => l.ProfessorId);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Assignments)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.ProfessorId);



            // Course relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Professors)
            //    .WithMany(p => p.Courses)
            //    .UsingEntity(j => j.ToTable("CourseProfessors"));

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Syllabuses)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lectures)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Course)
                .HasForeignKey(n => n.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Ratings)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);



            // Feed relationships
            modelBuilder.Entity<Feed>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Feed)
                .HasForeignKey(c => c.FeedId);

            modelBuilder.Entity<Feed>()
                .HasMany(f => f.Reactions)
                .WithOne(r => r.Feed)
                .HasForeignKey(r => r.FeedId);



            // Comment relationships
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Feed)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.FeedId);


            // Reply relationships
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId);


            // Reaction relationships
            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Feed)
                .WithMany(f => f.Reactions)
                .HasForeignKey(r => r.FeedId);

        }
    }
}
