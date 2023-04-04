using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Speakers
{
    public class DeleteModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public DeleteModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Speakers == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers.FirstOrDefaultAsync(m => m.SpeakerID == id);

            if (speaker == null)
            {
                return NotFound();
            }
            else 
            {
                Speaker = speaker;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Speakers == null)
            {
                return NotFound();
            }
            var speaker = await _context.Speakers.FindAsync(id);

            if (speaker != null)
            {
                Speaker = speaker;
                _context.Speakers.Remove(Speaker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
