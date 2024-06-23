using EducationAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAPI.Entities
{
    public class Practice
    {
        public int Id { get; set; }
        public string Quest { get; set; }
        public string FunctionName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public ICollection<TestCase> TestCases { get; set; }
    }
}
