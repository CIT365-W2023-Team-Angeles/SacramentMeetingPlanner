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

        public List<SelectListItem> HymnList { get; set; }

        public IActionResult OnGet()
        {
            HymnList = _context.Hymns.Select(a => new SelectListItem
            {
                Value = a.DisplayName,
                Text = a.DisplayName
            }).ToList().OrderBy(a => Int32.Parse(a.Value.Split(" - ")[0])).ToList();
            
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; }
        public Meeting emptyMeeting { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

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
