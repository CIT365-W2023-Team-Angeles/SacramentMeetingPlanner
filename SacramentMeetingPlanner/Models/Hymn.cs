using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        public int HymnID { get; set; }

        [Required(ErrorMessage = "Enter the Hymn title")]
        [RegularExpression(@"^([A-Z][a-z]+)$", ErrorMessage = "Hymn title must be capitalized and only contain letters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter the Hymn number")]
        [Range(1, 341, ErrorMessage = "Hymn number must be a number between 1 and 341.")]
        public int Number { get; set; }

        public ICollection<Selection> Selections { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{Number} - {Title}";
            }
        }
    }

}
