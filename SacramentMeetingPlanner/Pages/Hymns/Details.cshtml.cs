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
    }
}
