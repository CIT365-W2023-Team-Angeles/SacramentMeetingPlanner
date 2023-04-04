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
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public IndexModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        public IList<Speaker> Speaker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Speakers != null)
            {
                Speaker = await _context.Speakers.ToListAsync();
            }
        }
    }
}
