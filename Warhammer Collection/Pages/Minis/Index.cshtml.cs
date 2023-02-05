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
    public class IndexModel : PageModel
    {
        private readonly Warhammer_Collection.Data.Warhammer_CollectionContext _context;

        public IndexModel(Warhammer_Collection.Data.Warhammer_CollectionContext context)
        {
            _context = context;
        }

        public IList<Mini> Mini { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? ModelName { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Mini != null)
            {
                Mini = await _context.Mini.ToListAsync();
            }
        }
    }
}
