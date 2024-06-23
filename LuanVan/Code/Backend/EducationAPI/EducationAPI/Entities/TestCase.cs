using EducationAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAPI.Entities
{
    public class TestCase
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Expected { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int PracticeId { get; set; }
        public Practice? Practice { get; set; }

    }
}
