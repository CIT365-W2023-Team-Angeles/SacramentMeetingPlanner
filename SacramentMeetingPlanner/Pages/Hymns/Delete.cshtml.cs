using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Hymns
{
    public class DeleteModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public DeleteModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hymn Hymn { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hymns == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymns.FirstOrDefaultAsync(m => m.HymnID == id);

            if (hymn == null)
            {
                return NotFound();
            }
            else 
            {
                Hymn = hymn;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hymns == null)
            {
                return NotFound();
            }
            var hymn = await _context.Hymns.FindAsync(id);

            if (hymn != null)
            {
                Hymn = hymn;
                _context.Hymns.Remove(Hymn);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
