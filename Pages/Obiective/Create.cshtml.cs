using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P_Galchis_Cristian.Data;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Pages.Obiective
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public CreateModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StilID"] = new SelectList(_context.Set<Stil>(), "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Obiectiv Obiectiv { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Obiectiv.Add(Obiectiv);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
