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

namespace SacramentMeetingPlanner.Pages.Speakers
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public EditModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Speaker Speaker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Speakers == null)
            {
                return NotFound();
            }

            var speaker =  await _context.Speakers.FirstOrDefaultAsync(m => m.ID == id);
            if (speaker == null)
            {
                return NotFound();
            }
            Speaker = speaker;
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

            _context.Attach(Speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(Speaker.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpeakerExists(int id)
        {
          return _context.Speakers.Any(e => e.ID == id);
        }
    }
}
