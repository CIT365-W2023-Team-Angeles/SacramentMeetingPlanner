using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SacramentMeetingPlanner.Models
{
    public class Assignments
    {        
        public int AssignmentsID { get; set; }
        public int MeetingID { get; set; }
        public int SpeakerID { get; set; }

        public Meeting Meeting { get; set; }
        public Speaker Speaker { get; set; }
    }
}

