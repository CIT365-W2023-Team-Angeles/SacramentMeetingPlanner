﻿using System;
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

        private List<SelectListItem> conductingList;

        public List<SelectListItem> GetConductingList()
        {
            return conductingList;
        }

        public void SetConductingList(List<SelectListItem> value)
        {
            conductingList = value;
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
                List<string> l = new List<string> { "Bishop Clifford Duke", "Ethan Arredondo, 1st Counselor", "Jim Elliott, 2nd Counselor" };
                SetConductingList(l.Select(x => new SelectListItem { Text = x, Value = x }).ToList());
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
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var meetingToUpdate = await _context.Meetings.FindAsync(id);


            if (await TryUpdateModelAsync<Meeting>(
                meetingToUpdate,
                "meeting",
                s => s.MeetingID, s => s.MeetingDate, s => s.Conducting, s => s.OpeningHymn, s => s.Invocation, s => s.SacramentHymn, s => s.Speaker1, s => s.Speaker2, s => s.Speaker3, s => s.ClosingHymn, s => s.Benediction, s => s.Notes))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    if (!MeetingExists(Meeting.MeetingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Page();
        }

        private bool MeetingExists(int id)
        {
          return _context.Meetings.Any(e => e.MeetingID == id);
        }
    }
}
