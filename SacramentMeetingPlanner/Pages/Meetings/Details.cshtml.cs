using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Meetings
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public DetailsModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

      public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meetings
                .Include(s => s.Assignments)
                .ThenInclude(e => e.Speaker)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeetingID == id);

            //var meeting = await _context.Meetings.FirstOrDefaultAsync(m => m.MeetingID == id);

            if (Meeting == null)
            {
                return NotFound();
            }
            //else 
            //{
            //    Meeting = meeting;
            //}
            return Page();
        }
    }
}
