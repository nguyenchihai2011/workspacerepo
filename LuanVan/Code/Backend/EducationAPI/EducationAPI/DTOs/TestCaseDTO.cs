using EducationAPI.Entities;
using EducationAPI.Models;

namespace EducationAPI.DTOs
{
    public class TestCaseDTO
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Expected { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int PracticeId { get; set; }
    }
}
