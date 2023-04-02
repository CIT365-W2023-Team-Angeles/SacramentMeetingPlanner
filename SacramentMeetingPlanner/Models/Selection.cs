using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SacramentMeetingPlanner.Models
{
    public class Selection
    {
        public int SelectionID { get; set; }
        public int MeetingID { get; set; }
        public int HymnID { get; set; }
        
        public Meeting Meeting { get; set; }
        public Hymn Hymn { get; set; }
    }
}
