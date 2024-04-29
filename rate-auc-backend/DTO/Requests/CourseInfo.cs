﻿using RateAucProfessors.Models;
using System.ComponentModel.DataAnnotations;

namespace RateAucProfessors.DTO.Requests
{
    public class CourseInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credit_Hours { get; set; }
        public int DepartmentId { get; set; }
        public int ProfessorId { get; set; }
    }
}
