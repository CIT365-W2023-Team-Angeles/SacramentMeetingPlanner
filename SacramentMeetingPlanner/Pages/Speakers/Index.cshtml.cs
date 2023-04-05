using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;
using SacramentMeetingPlanner.Models.ViewModels;

namespace SacramentMeetingPlanner.Pages.Speakers
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public IndexModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TopicSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Speaker> Speaker { get; set; } = default!;

        public SpeakerIndexData SpeakerData { get; set; }
        public int SpeakerID { get; set; }
        public int MeetingID { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, int? id, int? meetingID)
        {
            SpeakerData = new SpeakerIndexData();
            //SpeakerData.Speakers = await _context.Speakers
            //    .Include(i => i.Topic).OrderBy(i => i.Name).ToListAsync();

            if (id != null )
            {
                SpeakerID = id.Value;
                Speaker speaker = SpeakerData.Speakers.Where(i => i.SpeakerID == id.Value).Single();
                SpeakerData.Meetings = speaker.Meetings;
            }

            if (meetingID != null )
            {
                MeetingID = meetingID.Value;
                IEnumerable<Assignments> Assignments = await _context.Assignments
                    .Where(x => x.MeetingID == meetingID.Value)
                    .Include(i => i.Speaker).ToListAsync();
                SpeakerData.Assignments = Assignments;
            }

            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TopicSort = String.IsNullOrEmpty(sortOrder) ? "topic_desc" : "";

            CurrentFilter = searchString;

            IQueryable<Speaker> speakersIQ = from s in _context.Speakers
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                speakersIQ = speakersIQ.Where(s => s.Name.Contains(searchString)
                                       || s.Topic.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    speakersIQ = speakersIQ.OrderByDescending(s => s.Name);
                    break;
                case "topic":
                    speakersIQ = speakersIQ.OrderBy(s => s.Topic);
                    break;
                case "topic_desc":
                    speakersIQ = speakersIQ.OrderByDescending(s => s.Topic);
                    break;
                default:
                    speakersIQ = speakersIQ.OrderBy(s => s.Name);
                    break;
            }

            Speaker = await speakersIQ.AsNoTracking().ToListAsync();
        }
    }
}