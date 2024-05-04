
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.Models;
using System.Collections.Generic;

namespace RateAucProfessors.ObjectsMapping
{
    public class Mapper
    {
        // Mapping functions for Assignment
        //public Assignment MapToAssignment(AssignmentInfo dto, string userId)
        //{
        //    return new Assignment
        //    {
        //        Content = dto.Content,
        //        UploadDate = dto.UploadDate,
        //        ProfessorId = dto.ProfessorId,
        //        CourseId = dto.CourseId,
        //        UserId = userId
        //    };
        //}
        //public List<Assignment> MapToAssignment(List<AssignmentInfo> dtos, string userId)
        //{
        //    List<Assignment> assignmnets = new List<Assignment>();
        //    foreach (var dto in dtos)
        //    {
        //        Assignment assignmnet = new Assignment
        //        {
        //            Content = dto.Content,
        //            UploadDate = dto.UploadDate,
        //            ProfessorId = dto.ProfessorId,
        //            CourseId = dto.CourseId,
        //            UserId = userId
        //        };
        //        assignmnets.Add(assignmnet);
        //    }
        //    return assignmnets;
        //}

        // Mapping functions for Comment

        public Comment MapToComment(CommentInfo dto, string userId)
        {
            return new Comment
            {
                Content = dto.Content,
                Timestamp = dto.Timestamp,
                FeedId = dto.FeedId,
                UserId = userId,
                ReviewId = dto.ReviewId

            };
        }
        public List<Comment> MapToComment(List<CommentInfo> dtos, string userId)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var dto in dtos)
            {
                Comment comment = new Comment
                {
                    Content = dto.Content,
                    Timestamp = dto.Timestamp,
                    FeedId = dto.FeedId,
                    UserId = userId,
                    ReviewId = dto.ReviewId
                };
                comments.Add(comment);
            }
            return comments;
        }

        // Mapping functions for Course

        public Course MapToCourse(CourseInfo dto)
        {
            return new Course
            {
                Name = dto.Name,
                Description = dto.Description,
                Code = dto.Code,
                Credit_Hours = dto.Credit_Hours,
                DepartmentId = dto.DepartmentId,
            };
        }
        public List<Course> MapToCourse(List<CourseInfo> dtos)
        {
            List<Course> courses = new List<Course>();
            foreach (var dto in dtos)
            {
                Course course = new Course
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Code = dto.Code,
                    Credit_Hours = dto.Credit_Hours,
                    DepartmentId = dto.DepartmentId,
                };
                courses.Add(course);
            }
            return courses;
        }

        public Course MapToCourseDataSeeding(CourseSeeding dto,int departmentId)
        {
            return new Course
            {
                Name = dto.Name,
                Description = dto.Description,
                Code = dto.Code,
                Credit_Hours = dto.Credit_Hours,
                DepartmentId = departmentId
            };
        }

        // Mapping functions for Department
        public Department MapToDepartment(DepartmentInfo dto)
        {
            return new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
        public List<Department> MapToDepartment(List<DepartmentInfo> dtos)
        {
            List<Department> departments = new List<Department>();
            foreach (var dto in dtos)
            {
                Department department = new Department
                {
                    Name = dto.Name,
                    Description = dto.Description
                };
                departments.Add(department);
            }
            return departments;
        }

        // Mapping functions for Document
        public Document MapToDocument(DocumentInfo dto, string userId)
        {
            return new Document
            {
                Document_type = dto.Document_type,
                Content = dto.Content,
                UploadDate = dto.UploadDate,
                DocumentUrl = dto.DocumentUrl,
                UserId = userId,
                ProfessorId = dto.ProfessorId,
                CourseId = dto.CourseId
            };
        }
        public List<Document> MapToDocument(List<DocumentInfo> dtos, string userId)
        {
            List<Document> documents = new List<Document>();
            foreach (var dto in dtos)
            {
                Document document = new Document
                {
                    Document_type = dto.Document_type,
                    Content = dto.Content,
                    UploadDate = dto.UploadDate,
                    DocumentUrl = dto.DocumentUrl,
                    UserId = userId,
                    ProfessorId = dto.ProfessorId,
                    CourseId = dto.CourseId
                };
                documents.Add(document);
            }
            return documents;
        }

        // Mapping functions for Feed
        public Feed MapToFeed(FeedInfo dto, string userId)
        {
            return new Feed
            {
                Content = dto.Content,
                Timestamp = dto.Timestamp,
                UserId = userId
            };
        }
        public List<Feed> MapToFeed(List<FeedInfo> dtos, string userId)
        {
            List<Feed> feeds = new List<Feed>();
            foreach (var dto in dtos)
            {
                Feed feed = new Feed
                {
                    Content = dto.Content,
                    Timestamp = dto.Timestamp,
                    UserId = userId
                };
                feeds.Add(feed);
            }
            return feeds;
        }

        // Mapping functions for Major
        public Major MapToMajor(MajorInfo dto)
        {
            return new Major
            {
                Name = dto.Name,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId
            };
        }
        public List<Major> MapToMajor(List<MajorInfo> dtos)
        {
            List<Major> majors = new List<Major>();
            foreach (var dto in dtos)
            {
                Major major = new Major
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    DepartmentId = dto.DepartmentId
                };
                majors.Add(major);
            }
            return majors;
        }

        // Mapping functions for Lecture
        //public Lecture MapToLecture(LectureInfo dto, string userId)
        //{
        //    return new Lecture
        //    {
        //        Content = dto.Content,
        //        UploadDate = dto.UploadDate,
        //        UserId = userId,
        //        ProfessorId = dto.ProfessorId,
        //        CourseId = dto.CourseId
        //    };
        //}
        //public List<Lecture> MapToLecture(List<LectureInfo> dtos, string userId)
        //{
        //    List<Lecture> lectures = new List<Lecture>();
        //    foreach (var dto in dtos)
        //    {
        //        Lecture lecture = new Lecture
        //        {
        //            Content = dto.Content,
        //            UploadDate = dto.UploadDate,
        //            UserId = userId,
        //            ProfessorId = dto.ProfessorId,
        //            CourseId = dto.CourseId
        //        };
        //        lectures.Add(lecture);
        //    }
        //    return lectures;
        //}

        //// Mapping functions for Note
        //public Note MapToNote(NoteInfo dto, string userId)
        //{
        //    return new Note
        //    {
        //        Content = dto.Content,
        //        UploadDate = dto.UploadDate,
        //        UserId = userId,
        //        ProfessorId = dto.ProfessorId,
        //        CourseId = dto.CourseId
        //    };
        //}
        //public List<Note> MapToNote(List<NoteInfo> dtos, string userId)
        //{
        //    List<Note> notes = new List<Note>();
        //    foreach (var dto in dtos)
        //    {
        //        Note note = new Note
        //        {
        //            Content = dto.Content,
        //            UploadDate = dto.UploadDate,
        //            UserId = userId,
        //            ProfessorId = dto.ProfessorId,
        //            CourseId = dto.CourseId
        //        };
        //        notes.Add(note);
        //    }
        //    return notes;
        //}

        // Mapping functions for Professor
        public Professor MapToProfessor(ProfessorInfo dto)
        {
            return new Professor
            {
                Name = dto.Name,
                Email = dto.Email,
                Bio = dto.Bio,
                DepartmentId = dto.DepartmentId
            };
        }
        public List<Professor> MapToProfessor(List<ProfessorInfo> dtos)
        {
            List<Professor> professors = new List<Professor>();
            foreach (var dto in dtos)
            {
                Professor professor = new Professor
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Bio = dto.Bio,
                    DepartmentId = dto.DepartmentId
                };
                professors.Add(professor);
            }
            return professors;
        }

        // Mapping functions for Rating
        public Review MapToReview(ReviewInfo dto, string userId)
        {
            return new Review
            {
                Content = dto.Content,
                Timestamp = dto.Timestamp,
                Value = dto.Value,
                ProfessorId = dto.ProfessorId,
                UserId = userId,
                CourseId = dto.CourseId
            };
        }
        public List<Review> MapToReview(List<ReviewInfo> dtos, string userId)
        {
            List<Review> reviews = new List<Review>();
            foreach (var dto in dtos)
            {
                Review review = new Review
                {
                    Content = dto.Content,
                    Timestamp = dto.Timestamp,
                    Value = dto.Value,
                    ProfessorId = dto.ProfessorId,
                    UserId = userId,
                    CourseId = dto.CourseId
                };
                reviews.Add(review);
            }
            return reviews;
        }

        // Mapping functions for Reaction
        public Reaction MapToReaction(ReactionInfo dto, string userId)
        {
            return new Reaction
            {
                IsLike = dto.IsLike,
                Timestamp = dto.Timestamp,
                FeedId = dto.FeedId,
                UserId = userId,
                CommentId = dto.CommentId,
                ReviewId = dto.ReviewId,
                ReplyId = dto.ReplyId
            };
        }
        public List<Reaction> MapToReaction(List<ReactionInfo> dtos, string userId)
        {
            List<Reaction> reactions = new List<Reaction>();
            foreach (var dto in dtos)
            {
                Reaction reaction = new Reaction
                {
                    IsLike = dto.IsLike,
                    Timestamp = dto.Timestamp,
                    FeedId = dto.FeedId,
                    UserId = userId,
                    CommentId = dto.CommentId,
                    ReviewId = dto.ReviewId,
                    ReplyId = dto.ReplyId
                };
                reactions.Add(reaction);
            }
            return reactions;
        }

        // Mapping functions for Reply
        public Reply MapToReply(ReplyInfo dto, string userId)
        {
            return new Reply
            {
                Content = dto.Content,
                Timestamp = dto.Timestamp,
                CommentId = dto.CommentId,
                UserId = userId
            };
        }
        public List<Reply> MapToReply(List<ReplyInfo> dtos, string userId)
        {
            List<Reply> replies = new List<Reply>();
            foreach (var dto in dtos)
            {
                Reply reply = new Reply
                {
                    Content = dto.Content,
                    Timestamp = dto.Timestamp,
                    CommentId = dto.CommentId,
                    UserId = userId
                };
                replies.Add(reply);
            }
            return replies;
        }

        // Mapping functions for Student
        public Student MapToStudent(StudentInfo dto)
        {
            return new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Standing = dto.Standing,
                GraduationYear = dto.GraduationYear,
                Email = dto.FirstName + ' ' + dto.LastName,
                UserName = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Student_Id = dto.Student_Id,
                Color = RandomColor(),
                Gender = dto.Gender
            };
        }
        public Student MapToStudent(StudentInfo dto, string userId)
        {
            return new Student
            {
                Id = userId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Standing = dto.Standing,
                GraduationYear = dto.GraduationYear,
                Email = dto.FirstName + ' ' + dto.LastName,
                UserName = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Student_Id = dto.Student_Id,
                Color = RandomColor(),
                Gender = dto.Gender
            };
        }
        public string RandomColor()
            {
                string[] colors = new string[] { "#6171BA", "#218B8B", "#EF8CCB", "#31B0CD", "#A083C9" };
                Random random = new Random();
                int index = random.Next(colors.Length);
                return colors[index];
            }

        
        public List<Student> MapToStudent(List<StudentInfo> dtos)
        {
            List<Student> students = new List<Student>();
            foreach (var dto in dtos)
            {
                Student student = new Student
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Standing = dto.Standing,
                    GraduationYear = dto.GraduationYear,
                    Email = dto.FirstName + ' ' + dto.LastName,
                    UserName = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Student_Id = dto.Student_Id
                };
                students.Add(student);
            }
            return students;
        }

        // Mapping functions for Syllabus
        //public Syllabus MapToSyllabus(SyllabusInfo dto, string userId)
        //{
        //    return new Syllabus
        //    {
        //        Content = dto.Content,
        //        UploadDate = dto.UploadDate,
        //        ProfessorId = dto.ProfessorId,
        //        CourseId = dto.CourseId,
        //        UserId = userId
        //    };
        //}
        //public List<Syllabus> MapToSyllabus(List<SyllabusInfo> dtos, string userId)
        //{
        //    List<Syllabus> syllabuses = new List<Syllabus>();
        //    foreach (var dto in dtos)
        //    {
        //        Syllabus syllabus = new Syllabus
        //        {
        //            Content = dto.Content,
        //            UploadDate = dto.UploadDate,
        //            ProfessorId = dto.ProfessorId,
        //            CourseId = dto.CourseId,
        //            UserId = userId
        //        };
        //        syllabuses.Add(syllabus);
        //    }
        //    return syllabuses;
        //}

    }
}
