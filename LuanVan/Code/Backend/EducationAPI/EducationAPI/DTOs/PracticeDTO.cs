using EducationAPI.Entities;
using EducationAPI.Models;

namespace EducationAPI.DTOs
{
    public class PracticeDTO
    {
        public int Id { get; set; }
        public string Quest { get; set; }
        public string FunctionName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int LessonId { get; set; }
        public ICollection<TestCaseDTO> TestCasesDTO { get; set; }
    }
}
