﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P_Galchis_Cristian.Data;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Pages.Stiluri
{
    public class EditModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public EditModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stil Stil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stil =  await _context.Stil.FirstOrDefaultAsync(m => m.ID == id);
            if (stil == null)
            {
                return NotFound();
            }
            Stil = stil;
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

            _context.Attach(Stil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StilExists(Stil.ID))
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

        private bool StilExists(int id)
        {
            return _context.Stil.Any(e => e.ID == id);
        }
    }
}
