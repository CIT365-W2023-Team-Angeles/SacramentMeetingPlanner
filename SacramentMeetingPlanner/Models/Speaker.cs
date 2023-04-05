using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the Topic")]
        [RegularExpression(@"^([A-Z][a-z]+)$", ErrorMessage = "Topic must be capitalized and only contain letters.")]
        public string Topic { get; set; }


        public Meeting Meeting { get; set; }
        public ICollection<Assignments> Assignments { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
    }
}

