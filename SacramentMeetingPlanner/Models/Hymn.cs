using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        public int HymnID { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }

        public ICollection<Assignments> Assignments { get; set; }
    }
}
