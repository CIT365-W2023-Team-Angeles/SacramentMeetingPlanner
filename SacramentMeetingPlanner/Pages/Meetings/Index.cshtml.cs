using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly ChurchContext _context;

        public IndexModel(ChurchContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Meeting> Meeting { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Meeting> meetingsIQ = from s in _context.Meetings
            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                //meetingsIQ = meetingsIQ.Where(s => s.MeetingDate.Contains(searchString)
                //                       || s.Conducting.Contains(searchString));
                meetingsIQ = meetingsIQ.Where(s => s.Conducting.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    meetingsIQ = meetingsIQ.OrderByDescending(s => s.Conducting);
                    break;
                case "Date":
                    meetingsIQ = meetingsIQ.OrderBy(s => s.MeetingDate);
                    break;
                case "date_desc":
                    meetingsIQ = meetingsIQ.OrderByDescending(s => s.MeetingDate);
                    break;
                default:
                    meetingsIQ = meetingsIQ.OrderBy(s => s.Conducting);
                    break;
            }

            Meeting = await meetingsIQ.AsNoTracking().ToListAsync();
        }
    }
}

