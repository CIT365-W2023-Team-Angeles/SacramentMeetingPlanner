using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Meetings
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public EditModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Meeting Meeting { get; set; } = default!;
        public List<SelectListItem> ConductingList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meetings.FindAsync(id);

            if (Meeting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var meetingToUpdate = await _context.Meetings.FindAsync(id);

            if (meetingToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Meeting>(
                meetingToUpdate,
                "meeting",
                s => s.MeetingID, s => s.MeetingDate, s => s.Conducting, s => s.OpeningHymn, s => s.Invocation, s => s.SacramentHymn, s => s.ClosingHymn, s => s.Benediction, s => s.Notes))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            {
                List<string> l = new List<string> { "", "Bishop Clifford Duke", "Ethan Arredondo, 1st Counselor", "Jim Elliott, 2nd Counselor" };
                ConductingList = l.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            }

            return Page();
        }
        private bool MeetingExists(int id)
        {
          return _context.Meetings.Any(e => e.MeetingID == id);
        }
    }
}
