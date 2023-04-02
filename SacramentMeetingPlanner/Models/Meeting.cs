using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Conducting { get; set; }
        public int NumSpeakers { get; set; }

        public ICollection<Assignments> Assignments { get; set; }
    }
}
