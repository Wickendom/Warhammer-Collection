using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warhammer_Collection.Data;
using Warhammer_Collection.Models;

namespace Warhammer_Collection.Pages.Minis
{
    public class EditModel : PageModel
    {
        private readonly Warhammer_Collection.Data.Warhammer_CollectionContext _context;

        public EditModel(Warhammer_Collection.Data.Warhammer_CollectionContext context)
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

            var mini =  await _context.Mini.FirstOrDefaultAsync(m => m.Id == id);
            if (mini == null)
            {
                return NotFound();
            }
            Mini = mini;
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

            _context.Attach(Mini).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniExists(Mini.Id))
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

        private bool MiniExists(int id)
        {
          return (_context.Mini?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
