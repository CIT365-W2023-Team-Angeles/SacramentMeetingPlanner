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

namespace SacramentMeetingPlanner.Pages.Hymns
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public EditModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hymn Hymn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hymns == null)
            {
                return NotFound();
            }

            var hymn =  await _context.Hymns.FirstOrDefaultAsync(m => m.HymnID == id);
            if (hymn == null)
            {
                return NotFound();
            }
            Hymn = hymn;
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

            _context.Attach(Hymn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HymnExists(Hymn.HymnID))
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

        private bool HymnExists(int id)
        {
          return _context.Hymns.Any(e => e.HymnID == id);
        }
    }
}
