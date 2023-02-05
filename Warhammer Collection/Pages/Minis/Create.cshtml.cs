using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warhammer_Collection.Data;
using Warhammer_Collection.Models;

namespace Warhammer_Collection.Pages.Minis
{
    public class CreateModel : PageModel
    {
        private readonly Warhammer_Collection.Data.Warhammer_CollectionContext _context;

        public CreateModel(Warhammer_Collection.Data.Warhammer_CollectionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mini Mini { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Mini == null || Mini == null)
            {
                return Page();
            }

            _context.Mini.Add(Mini);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
