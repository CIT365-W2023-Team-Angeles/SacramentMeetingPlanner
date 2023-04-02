using SacramentMeetingPlanner.Models;
using System.Diagnostics;

namespace SacramentMeetingPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(ChurchContext context)
        {
            // Look for any speakers.
            if (context.Speakers.Any())
            {
                return;   // DB has been seeded
            }

            var speakers = new Speaker[]
            {
                new Speaker{Name="Alexander Carson",Topic="Faith"},
                new Speaker{Name="Meredith Alonso",Topic="Repentance"},
                new Speaker{Name="Arturo Anand",Topic="Baptism"},
                new Speaker{Name="Gytis Barzdukas",Topic="The Gift of the Holy Ghost"},
                new Speaker{Name="Yan Li",Topic="The Priesthood"},
                new Speaker{Name="Peggy Justice",Topic="The Plan of Salvation"},
                new Speaker{Name="Laura Norman",Topic="Jesus, Our Savior and Redeemer"},
                new Speaker{Name="Nino Olivetto",Topic="Jesus is Risen"}
            };

            context.Speakers.AddRange(speakers);
            context.SaveChanges();

            var meetings = new Meeting[]
            {
                new Meeting{MeetingDate=DateTime.Parse("2023-02-26"),Conducting="Bishop Clifford Duke", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-5"),Conducting="Ethan Arredando, 1st Counselor", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-12"),Conducting="Jim Elliot, 2nd Counselor", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-19"),Conducting="Bishop Clifford Duke", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-26"),Conducting="Ethan Arredando, 1st Counselor", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-04-9"),Conducting="Jim Elliot, 2nd Counselor", NumSpeakers=0},
                new Meeting{MeetingDate=DateTime.Parse("2023-04-16"),Conducting="Bishop Clifford Duke", NumSpeakers=0}
            };

            context.Meetings.AddRange(meetings);
            context.SaveChanges();

            var assignments = new Assignments[]
            {
                new Assignments{SpeakerID=1,MeetingID=1},
                new Assignments{SpeakerID=2,MeetingID=1},
                new Assignments{SpeakerID=3,MeetingID=1},
                new Assignments{SpeakerID=4,MeetingID=2},
                new Assignments{SpeakerID=5,MeetingID=2},
                new Assignments{SpeakerID=6,MeetingID=2},
                new Assignments{SpeakerID=7,MeetingID=3},
                new Assignments{SpeakerID=8,MeetingID=3},
                new Assignments{SpeakerID=9,MeetingID=3},
                new Assignments{SpeakerID=10,MeetingID=4},
                new Assignments{SpeakerID=11,MeetingID=4},
                new Assignments{SpeakerID=12,MeetingID=4},
                new Assignments{SpeakerID=13,MeetingID=5},
                new Assignments{SpeakerID=14,MeetingID=5},
                new Assignments{SpeakerID=15,MeetingID=5},
                new Assignments{SpeakerID=16,MeetingID=6},
                new Assignments{SpeakerID=17,MeetingID=6},
                new Assignments{SpeakerID=18,MeetingID=6},
                new Assignments{SpeakerID=19,MeetingID=7},
                new Assignments{SpeakerID=20,MeetingID=7},
                new Assignments{SpeakerID=21,MeetingID=7},
                new Assignments{SpeakerID=22,MeetingID=8},
                new Assignments{SpeakerID=23,MeetingID=8},
                new Assignments{SpeakerID=24,MeetingID=8},
                new Assignments{SpeakerID=25,MeetingID=9},
                new Assignments{SpeakerID=26,MeetingID=9},
                new Assignments{SpeakerID=27,MeetingID=9},
            };

            context.Assignments.AddRange(assignments);
            context.SaveChanges();
        }
    }
}
