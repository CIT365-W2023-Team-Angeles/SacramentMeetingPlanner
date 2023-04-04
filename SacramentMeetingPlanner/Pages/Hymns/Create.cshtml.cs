using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Hymns
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.ChurchContext _context;

        public CreateModel(SacramentMeetingPlanner.Data.ChurchContext context)
        {
            _context = context;
        }

        public List<SelectListItem> HymnList { get; set; }

        public IActionResult OnGet()
        {

            HymnList = _context.Hymns.Select(a => new SelectListItem
            {
                Value = a.DisplayName,
                Text = a.DisplayName
            }).ToList().OrderBy(a => Int32.Parse(a.Value.Split(" - ")[0])).ToList();

            return Page();
        }

        [BindProperty]
        public Hymn Hymn { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hymns.Add(Hymn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
