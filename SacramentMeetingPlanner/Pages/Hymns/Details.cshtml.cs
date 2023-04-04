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
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public DetailsModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

      public Hymn Hymn { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hymns == null)
            {
                return NotFound();
            }

            Hymn = await _context.Hymns
                .Include(s => s.Selections)
                .ThenInclude(e => e.Meeting)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.HymnID == id);

            if (Hymn == null)
            {
                return NotFound();
            }
            //else 
            //{
            //    Hymn = hymn;
            //}
            return Page();
        }
    }
}
