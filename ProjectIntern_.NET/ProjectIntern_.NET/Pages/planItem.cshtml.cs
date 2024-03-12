using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectIntern_.NET.Data;
using ProjectIntern_.NET.Models;

namespace ProjectIntern_.NET.Pages
{
    public class planItemModel : PageModel
    {
        private readonly ProjectIntern_.NET.Data.ProjectIntern_NETContext _context;

        public planItemModel(ProjectIntern_.NET.Data.ProjectIntern_NETContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ES_YDENPYOD ES_YDENPYOD { get; set; }
        //[BindProperty]
        //public ES_YDENPYO ES_YDENPYO { get; set; }
        public IList<ES_YDENPYOD> listES_YDENPYOD { get; set; } = default!;
        public IList<ES_YDENPYOD> listES_YDENPYOD_ById { get; set; } = default!;
        public int? gyoNO { get; set; }
        public int? denpyoNO { get; set; }
        public async Task<IActionResult> OnGet(int? gyoNO, int? denpyoNO)
        {
            ES_YDENPYOD = await _context.ES_YDENPYOD.Where(m => m.denpyoNO == denpyoNO).FirstOrDefaultAsync(n => n.gyoNO == gyoNO);

            listES_YDENPYOD = await _context.ES_YDENPYOD.Where(n => n.denpyoNO == denpyoNO).ToListAsync();

            var maxId = (from e in _context.ES_YDENPYOD
                         select e.gyoNO).Max() + 1;

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? gyoNO)
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ES_YDENPYOD.Add(ES_YDENPYOD);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
