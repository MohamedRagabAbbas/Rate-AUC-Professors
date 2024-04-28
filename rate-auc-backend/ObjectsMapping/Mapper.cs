using RateAucProfessors.DTO.Requests;
using RateAucProfessors.Models;
using System.Collections.Generic;

namespace RateAucProfessors.ObjectsMapping
{
    public class Mapper
    {
        // Mapping functions for Assignment
        public Assignment MapToAssignment(AssignmentInfo dto, string userId)
        {
            return new Assignment
            {
                Content = dto.Content,
                UploadDate = dto.UploadDate,
                ProfessorId = dto.ProfessorId,
                CourseId = dto.CourseId,
                UserId = userId
            };
        }
        public List<Assignment> MapToAssignment(List<AssignmentInfo> dtos, string userId)
        {
            List<Assignment> assignmnets = new List<Assignment>();
            foreach (var dto in dtos)
            {
                Assignment assignmnet = new Assignment
                {
                    Content = dto.Content,
                    UploadDate = dto.UploadDate,
                    ProfessorId = dto.ProfessorId,
                    CourseId = dto.CourseId,
                    UserId = userId
                };
                assignmnets.Add(assignmnet);
            }
            return assignmnets;
        }

        // Mapping functions for Comment

        public Comment MapToComment(CommentInfo dto, string userId)
        {
            return new Comment
            {
                Content = dto.Content,
                Timestamp = dto.Timestamp,
                FeedId = dto.FeedId,
                UserId = userId
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
                    UserId = userId
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
                DepartmentId = dto.DepartmentId
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
                    DepartmentId = dto.DepartmentId
                };
                courses.Add(course);
            }
            return courses;
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

        // Mapping functions for Lecture
        public Lecture MapToLecture(LectureInfo dto, string userId)
        {
            return new Lecture
            {
                Content = dto.Content,
                UploadDate = dto.UploadDate,
                UserId = userId,
                ProfessorId = dto.ProfessorId,
                CourseId = dto.CourseId
            };
        }
        public List<Lecture> MapToLecture(List<LectureInfo> dtos, string userId)
        {
            List<Lecture> lectures = new List<Lecture>();
            foreach (var dto in dtos)
            {
                Lecture lecture = new Lecture
                {
                    Content = dto.Content,
                    UploadDate = dto.UploadDate,
                    UserId = userId,
                    ProfessorId = dto.ProfessorId,
                    CourseId = dto.CourseId
                };
                lectures.Add(lecture);
            }
            return lectures;
        }

        // Mapping functions for Note
        public Note MapToNote(NoteInfo dto, string userId)
        {
            return new Note
            {
                Content = dto.Content,
                UploadDate = dto.UploadDate,
                UserId = userId,
                ProfessorId = dto.ProfessorId,
                CourseId = dto.CourseId
            };
        }
        public List<Note> MapToNote(List<NoteInfo> dtos, string userId)
        {
            List<Note> notes = new List<Note>();
            foreach (var dto in dtos)
            {
                Note note = new Note
                {
                    Content = dto.Content,
                    UploadDate = dto.UploadDate,
                    UserId = userId,
                    ProfessorId = dto.ProfessorId,
                    CourseId = dto.CourseId
                };
                notes.Add(note);
            }
            return notes;
        }

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
        public Rating MapToRating(RatingInfo dto, string userId)
        {
            return new Rating
            {
                Timestamp = dto.Timestamp,
                Value = dto.Value,
                Comments = dto.Comments,
                ProfessorId = dto.ProfessorId,
                UserId = userId,
                CourseId = dto.CourseId
            };
        }
        public List<Rating> MapToRating(List<RatingInfo> dtos, string userId)
        {
            List<Rating> ratings = new List<Rating>();
            foreach (var dto in dtos)
            {
                Rating rating = new Rating
                {
                    Timestamp = dto.Timestamp,
                    Value = dto.Value,
                    Comments = dto.Comments,
                    ProfessorId = dto.ProfessorId,
                    UserId = userId,
                    CourseId = dto.CourseId
                };
                ratings.Add(rating);
            }
            return ratings;
        }

        // Mapping functions for Reaction
        public Reaction MapToReaction(ReactionInfo dto, string userId)
        {
            return new Reaction
            {
                IsLike = dto.IsLike,
                Timestamp = dto.Timestamp,
                FeedId = dto.FeedId,
                UserId = userId
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
                    UserId = userId
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

    }
}
