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
using Microsoft.AspNetCore.Identity;


namespace P_Galchis_Cristian.Pages.Bilete
{
    public class EditModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public EditModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet =  await _context.Bilet.FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }
            Bilet = bilet;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
           ViewData["ObiectivID"] = new SelectList(_context.Obiectiv, "ID", "Denumire");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(Bilet.ID))
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

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.ID == id);
        }
    }
}
