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
        public List<SelectListItem> HymnList { get; set; }
        public List<SelectListItem> ConductingList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting =  await _context.Meetings.FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            {
                List<string> l = new List<string> { "", "Bishop Clifford Duke", "Ethan Arredondo, 1st Counselor", "Jim Elliott, 2nd Counselor" };
                ConductingList = l.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            }

            Meeting = meeting;

            HymnList = _context.Hymns.Select(a => new SelectListItem
            {
                Value = a.DisplayName,
                Text = a.DisplayName
            }).ToList().OrderBy(a => Int32.Parse(a.Value.Split(" - ")[0])).ToList();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if (await TryUpdateModelAsync<Meeting>(
            //    meetingToUpdate,
            //    "meeting",
            //    s => s.MeetingID, s => s.MeetingDate, s => s.Conducting, s => s.OpeningHymn, s => s.Invocation, s => s.SacramentHymn, s => s.ClosingHymn, s => s.Benediction, s => s.Notes, s=> s.Assignments))
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch DbUpdateConcurrencyException
            //{
            //    if (!MeetingExists(Meeting.MeetingID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool MeetingExists(int id)
        {
          return _context.Meetings.Any(e => e.MeetingID == id);
        }
    }
}
