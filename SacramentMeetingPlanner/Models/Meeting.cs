using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Enter a Date")]
        [DataType(DataType.Date), Display(Name = "Meeting Date"),DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }

        [Required(ErrorMessage = "Select a member of the bishopric.")]
        public string Conducting { get; set; }

        [Display(Name = "Opening Hymn")]
        [Required(ErrorMessage = "Select a Hymn")]
        public string OpeningHymn { get; set; }

        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Invocation { get; set; }

        [Display(Name = "Sacrament Hymn")]
        [Required(ErrorMessage = "Select a Hymn between 169 and 196.")]
        public string SacramentHymn { get; set; }

        [Display(Name = "Speaker")]
        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Speaker1 { get; set; }

        [Display(Name = "Speaker")]
        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Speaker2 { get; set; }

        [Display(Name = "Speaker")]
        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Speaker3 { get; set; }

        [Display(Name = "Closing Hymn")]
        [Required(ErrorMessage = "Select a Hymn.")]
        public string ClosingHymn { get; set; }

        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Benediction { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Number of Speakers")]
        public int NumSpeakers { get; set; }

        public ICollection<Assignments> Assignments { get; set; }
    }
}
