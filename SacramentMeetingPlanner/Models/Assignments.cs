using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SacramentMeetingPlanner.Models
{
    public enum Conducting
    {
        Bishop, Counselor1, Counselor2
    }
    public class Assignments
    {        
        public int AssignmentsID { get; set; }
        public int MeetingID { get; set; }
        public int SpeakerID { get; set; }
        public string Topic { get; set; }

        public Meeting Meeting { get; set; }
        public Speaker Speaker { get; set; }
    }
}

