using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warhammer_Collection.Data;
using Warhammer_Collection.Models;

namespace Warhammer_Collection.Pages.Minis
{
    public class DeleteModel : PageModel
    {
        private readonly Warhammer_Collection.Data.Warhammer_CollectionContext _context;

        public DeleteModel(Warhammer_Collection.Data.Warhammer_CollectionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Mini Mini { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mini == null)
            {
                return NotFound();
            }

            var mini = await _context.Mini.FirstOrDefaultAsync(m => m.Id == id);

            if (mini == null)
            {
                return NotFound();
            }
            else 
            {
                Mini = mini;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Mini == null)
            {
                return NotFound();
            }
            var mini = await _context.Mini.FindAsync(id);

            if (mini != null)
            {
                Mini = mini;
                _context.Mini.Remove(Mini);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
