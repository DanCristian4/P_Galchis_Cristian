using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_Galchis_Cristian.Data;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Pages.Obiective
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public DeleteModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Obiectiv Obiectiv { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiectiv = await _context.Obiectiv.FirstOrDefaultAsync(m => m.ID == id);

            if (obiectiv == null)
            {
                return NotFound();
            }
            else
            {
                Obiectiv = obiectiv;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiectiv = await _context.Obiectiv.FindAsync(id);
            if (obiectiv != null)
            {
                Obiectiv = obiectiv;
                _context.Obiectiv.Remove(Obiectiv);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
