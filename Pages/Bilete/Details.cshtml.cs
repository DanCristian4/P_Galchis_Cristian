using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P_Galchis_Cristian.Data;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Pages.Bilete
{
    public class DetailsModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public DetailsModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        public Bilet Bilet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet
                           .Include(b => b.Client)     
                           .Include(b => b.Obiectiv)    
                           .FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }
            else
            {
                Bilet = bilet;
                ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
                ViewData["ObiectivID"] = new SelectList(_context.Obiectiv, "ID", "Denumire");
            }
            return Page();
        }
    }
}
