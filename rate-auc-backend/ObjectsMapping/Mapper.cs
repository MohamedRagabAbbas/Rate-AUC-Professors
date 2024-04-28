﻿using RateAucProfessors.DTO.Requests;
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
                Assignment assignmnet =  new Assignment
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

    }
}
