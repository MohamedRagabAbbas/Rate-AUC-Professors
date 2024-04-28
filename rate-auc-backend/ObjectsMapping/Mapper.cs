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



    }
}
