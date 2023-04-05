﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }

        [Display(Name = "Meeting Date")]
        [Required(ErrorMessage = "Enter a Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }

        public string Conducting { get; set; }

        [Display(Name = "Opening Hymn")]
        [Required(ErrorMessage = "Select a Hymn")]
        public string OpeningHymn { get; set; }

        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Invocation { get; set; }

        [Display(Name = "Sacrament Hymn")]
        [Required(ErrorMessage = "Select a Hymn.")]
        public string SacramentHymn { get; set; }

        [Display(Name = "Closing Hymn")]
        [Required(ErrorMessage = "Select a Hymn.")]
        public string ClosingHymn { get; set; }

        [Required(ErrorMessage = "Enter the first and last name")]
        [RegularExpression(@"^([A-Z][a-z]+\s[A-Z][a-z]+)$", ErrorMessage = "First and last name must be capitalized and only contain letters.")]
        public string Benediction { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Number of Speakers")]
        public int NumSpeakers { get; set; }
        public ICollection<Speaker> Speakers { get; set; }

        [Display(Name = "Hymn Selection")]
        public ICollection<Selection> Selection { get; set; }

        public ICollection<Assignments> Assignments { get; set; }
    }
}
