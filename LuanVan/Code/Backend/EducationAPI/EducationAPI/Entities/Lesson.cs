﻿using EducationAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAPI.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public DateTime Time { get; set; }
        public int Index { get; set; }
        public bool IsReview { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Quiz>? Quizzes { get; set; }
        public ICollection<Practice>? Practices { get; set; }
        public ICollection<StudentLesson>? StudentLessons { get; set; }

    }
}
