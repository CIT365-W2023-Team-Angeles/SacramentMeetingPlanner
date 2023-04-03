using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Meetings
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public CreateModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            {
                List<string> l = new List<string> { "", "Bishop Clifford Duke", "Ethan Arredondo, 1st Counselor", "Jim Elliott, 2nd Counselor" };
                ConductingList = l.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            }
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; }
        public List<SelectListItem> ConductingList { get; set; }
              

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyMeeting = new Meeting();

            if (await TryUpdateModelAsync<Meeting>(
                emptyMeeting,
                "meeting",   // Prefix for form value.
                s => s.MeetingID, s => s.MeetingDate, s => s.Conducting, s => s.OpeningHymn, s => s.Invocation, s => s.SacramentHymn, s => s.ClosingHymn, s => s.Benediction, s => s.Notes))
            {
                _context.Meetings.Add(emptyMeeting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
