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
                new Speaker{Name="Patrick Carson",Topic="Faith"},
                new Speaker{Name="MaryJane Carson",Topic="Faith"},
                new Speaker{Name="Meredith Alonso",Topic="Repentance"},
                new Speaker{Name="Kathy Henderson",Topic="Repentance"},
                new Speaker{Name="Ralph Henderson",Topic="Repentance"},
                new Speaker{Name="Arturo Anand",Topic="Baptism"},
                new Speaker{Name="Elizabeth Birch",Topic="Baptism"},
                new Speaker{Name="Phil Black",Topic="Baptism"},
                new Speaker{Name="Philomena Barzdukas",Topic="The Gift of the Holy Ghost"},
                new Speaker{Name="Cindy Barzdukas",Topic="The Gift of the Holy Ghost"},
                new Speaker{Name="Gytis Barzdukas",Topic="The Gift of the Holy Ghost"},
                new Speaker{Name="Yan Li",Topic="The Priesthood"},
                new Speaker{Name="Linda Rideout",Topic="The Priesthood"},
                new Speaker{Name="Daniel Drips",Topic="The Priesthood"},
                new Speaker{Name="Peggy Justice",Topic="The Plan of Salvation"},
                new Speaker{Name="Paul Johnson",Topic="The Plan of Salvation"},
                new Speaker{Name="Fernando Atilano",Topic="The Plan of Salvation"},
                new Speaker{Name="Laura Norman",Topic="Jesus, Our Savior and Redeemer"},
                new Speaker{Name="Nino Olivetto",Topic="Jesus is Risen"},
                new Speaker{Name="George Hathaway",Topic="Jesus is Risen"}
            };

            context.Speakers.AddRange(speakers);
            context.SaveChanges();

            var meetings = new Meeting[]
            {
                new Meeting{MeetingDate=DateTime.Parse("2023-02-26"),Conducting="Bishop Clifford Duke",OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-5"),Conducting="Ethan Arredando, 1st Counselor", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-12"),Conducting="Jim Elliot, 2nd Counselor", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-19"),Conducting="Bishop Clifford Duke", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-03-26"),Conducting="Ethan Arredando, 1st Counselor", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-04-9"),Conducting="Jim Elliot, 2nd Counselor", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3},
                new Meeting{MeetingDate=DateTime.Parse("2023-04-16"),Conducting="Bishop Clifford Duke", OpeningHymn="The Spirit of God 2", Invocation="Elizabeth Davison",SacramentHymn="As Now We Take the Sacrament 169",ClosingHymn="Come Follow Me 116", NumSpeakers=3}
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
            };

            context.Assignments.AddRange(assignments);
            context.SaveChanges();

            var hymns = new Hymn[]
            {
                new Hymn{Title="A Key Was Turned in Latter Days (Women)",Number=310},
                new Hymn{Title="A Mighty Fortress Is Our God",Number=68},
                new Hymn{Title="A Poor Wayfaring Man of Grief",Number=29},
                new Hymn{Title="A voice hath spoken from the dust",Number=275},
                new Hymn{Title="Abide with Me; 'Tis Eventide",Number=165},
                new Hymn{Title="Abide with Me!",Number=166},
                new Hymn{Title="Adam-ondi-Ahman",Number=49},
                new Hymn{Title="Again We Meet around the Board",Number=186},
                new Hymn{Title="Again, Our Dear Redeeming Lord",Number=179},
                new Hymn{Title="All Creatures of Our God and King",Number=62},
                new Hymn{Title="All Glory, Laud, and Honor",Number=69},
                new Hymn{Title="America the Beautiful",Number=338},
                new Hymn{Title="An Angel from on High",Number=13},
                new Hymn{Title="An Angel from on High",Number=328},
                new Hymn{Title="Angels We Have Heard on High",Number=203},
                new Hymn{Title="Arise, O Glorious Zion",Number=40},
                new Hymn{Title="Arise, O God, and Shine",Number=265},
                new Hymn{Title="As I have loved you",Number=308},
                new Hymn{Title="As I Search the Holy Scriptures",Number=277},
                new Hymn{Title="As I watch the rising sun",Number=306},
                new Hymn{Title="As Now We Take the Sacrament",Number=169},
                new Hymn{Title="As Sisters in Zion (Women)",Number=309},
                new Hymn{Title="As the Dew from Heaven Distilling",Number=149},
                new Hymn{Title="As the Shadows Fall",Number=168},
                new Hymn{Title="As Zion's Youth in Latter Days",Number=256},
                new Hymn{Title="Awake and Arise",Number=8},
                new Hymn{Title="Awake, Ye Saints of God, Awake!",Number=17},
                new Hymn{Title="Away in a Manger",Number=206},
                new Hymn{Title="Battle Hymn of the Republic",Number=60},
                new Hymn{Title="Be Still, My Soul",Number=124},
                new Hymn{Title="Be Thou Humble",Number=130},
                new Hymn{Title="Beautiful Zion, Built Above",Number=44},
                new Hymn{Title="Because I Have Been Given Much",Number=219},
                new Hymn{Title="Before Thee, Lord, I Bow My Head",Number=158},
                new Hymn{Title="Behold the Great Redeemer Die",Number=191},
                new Hymn{Title="Behold Thy Sons and Daughters, Lord",Number=238},
                new Hymn{Title="Behold, the Mountain of the Lord",Number=54},
                new Hymn{Title="Behold! A Royal Army",Number=251},
                new Hymn{Title="Bless Our Fast, We Pray",Number=138},
                new Hymn{Title="Brethren, pow'r by earthly standards",Number=320},
                new Hymn{Title="Brightly Beams Our Father's Mercy (Men's Choir)",Number=335},
                new Hymn{Title="Called to Serve",Number=249},
                new Hymn{Title="Carry On",Number=255},
                new Hymn{Title="Cast Thy Burden upon the Lord",Number=110},
                new Hymn{Title="Children of Our Heavenly Father",Number=299},
                new Hymn{Title="Choose the Right",Number=239},
                new Hymn{Title="Christ the Lord Is Risen Today",Number=200},
                new Hymn{Title="Come Along, Come Along",Number=244},
                new Hymn{Title="Come Away to the Sunday School",Number=276},
                new Hymn{Title="Come unto Him",Number=114},
                new Hymn{Title="Come unto Jesus",Number=117},
                new Hymn{Title="Come, All Whose Souls Are Lighted",Number=268},
                new Hymn{Title="Come, All Ye Saints of Zion",Number=38},
                new Hymn{Title="Come, All Ye Saints Who Dwell on Earth",Number=65},
                new Hymn{Title="Come, All Ye Sons of God (Men)",Number=322},
                new Hymn{Title="Come, Come, Ye Saints",Number=30},
                new Hymn{Title="Come, Come, Ye Saints (Men's Choir)",Number=326},
                new Hymn{Title="Come, Follow Me",Number=116},
                new Hymn{Title="Come, Let Us Anew",Number=217},
                new Hymn{Title="Come, Let Us Sing an Evening Hymn",Number=167},
                new Hymn{Title="Come, Listen to a Prophet's Voice",Number=21},
                new Hymn{Title="Come, O Thou King of Kings",Number=59},
                new Hymn{Title="Come, O Thou King of Kings (Men's Choir)",Number=332},
                new Hymn{Title="Come, Rejoice",Number=9},
                new Hymn{Title="Come, Sing to the Lord",Number=10},
                new Hymn{Title="Come, Thou Glorious Day of Promise",Number=50},
                new Hymn{Title="Come, We That Love the Lord",Number=119},
                new Hymn{Title="Come, Ye Children of the Lord",Number=58},
                new Hymn{Title="Come, Ye Disconsolate",Number=115},
                new Hymn{Title="Come, Ye Thankful People",Number=94},
                new Hymn{Title="Count Your Blessings",Number=241},
            };

            context.Hymns.AddRange(hymns);
            context.SaveChanges();

            //var selections = new Selection[]
            //{
            //    new Selection{HymnID=1,MeetingID=1},
            //    new Selection{HymnID=2,MeetingID=1},
            //    new Selection{HymnID=3,MeetingID=1},
            //    new Selection{HymnID=4,MeetingID=2},
            //    new Selection{HymnID=5,MeetingID=2},
            //    new Selection{HymnID=6,MeetingID=2},
            //    new Selection{HymnID=7,MeetingID=3},
            //    new Selection{HymnID=8,MeetingID=3},
            //    new Selection{HymnID=9,MeetingID=3},
            //    new Selection{HymnID=10,MeetingID=4},
            //    new Selection{HymnID=11,MeetingID=4},
            //    new Selection{HymnID=12,MeetingID=4},
            //    new Selection{HymnID=13,MeetingID=5},
            //    new Selection{HymnID=14,MeetingID=5},
            //    new Selection{HymnID=15,MeetingID=5},
            //    new Selection{HymnID=16,MeetingID=6},
            //    new Selection{HymnID=17,MeetingID=6},
            //    new Selection{HymnID=18,MeetingID=6},
            //    new Selection{HymnID=19,MeetingID=7},
            //    new Selection{HymnID=20,MeetingID=7},
            //    new Selection{HymnID=21,MeetingID=7}
            //};

            //context.Selections.AddRange(selections);
            //context.SaveChanges();
        }
    }
}
