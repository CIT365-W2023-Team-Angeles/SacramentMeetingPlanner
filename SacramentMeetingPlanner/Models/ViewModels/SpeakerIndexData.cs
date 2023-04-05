namespace SacramentMeetingPlanner.Models.ViewModels
{
    public class SpeakerIndexData
    {
        public IEnumerable<Speaker> Speakers { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
        public IEnumerable<Assignments> Assignments { get; set; }
    }
}
