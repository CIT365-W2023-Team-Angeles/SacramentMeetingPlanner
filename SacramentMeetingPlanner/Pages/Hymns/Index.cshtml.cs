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
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public IndexModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        public IList<Hymn> Hymn { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hymns != null)
            {
                Hymn = await _context.Hymns.ToListAsync();
            }
        }
    }
}
