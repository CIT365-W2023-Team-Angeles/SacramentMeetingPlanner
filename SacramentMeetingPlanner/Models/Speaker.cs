namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }     
        public string Name { get; set; }
        public string Topic { get; set; }

        public ICollection<Assignments> Assignments { get; set; }
    }
}

