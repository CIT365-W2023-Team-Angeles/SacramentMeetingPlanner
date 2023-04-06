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

        private List<SelectListItem> conductingList;

        public List<SelectListItem> GetConductingList()
        {
            return conductingList;
        }

        public void SetConductingList(List<SelectListItem> value)
        {
            conductingList = value;
        }

        public List<SelectListItem> HymnList { get; set; }

        public IActionResult OnGet()
        {
            {
                List<string> l = new List<string> { "Bishop Clifford Duke", "Ethan Arredondo, 1st Counselor", "Jim Elliott, 2nd Counselor" };
                SetConductingList(l.Select(x => new SelectListItem { Text = x, Value = x }).ToList());
            }

            HymnList = _context.Hymns.Select(a => new SelectListItem
            {
                Value = a.DisplayName,
                Text = a.DisplayName
            }).ToList().OrderBy(a => Int32.Parse(a.Value.Split(" - ")[0])).ToList();
            
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
                s => s.MeetingID, s => s.MeetingDate, s => s.Conducting, s => s.OpeningHymn, s => s.Invocation, s => s.SacramentHymn, s => s.Speaker1, s => s.Speaker2, s => s.Speaker3, s => s.ClosingHymn, s => s.Benediction, s => s.Notes, s => s.NumSpeakers))
            {
                _context.Meetings.Add(emptyMeeting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
