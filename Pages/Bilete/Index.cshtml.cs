﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P_Galchis_Cristian.Data;
using P_Galchis_Cristian.Models;

namespace P_Galchis_Cristian.Pages.Bilete
{
    public class IndexModel : PageModel
    {
        private readonly P_Galchis_Cristian.Data.P_Galchis_CristianContext _context;

        public IndexModel(P_Galchis_Cristian.Data.P_Galchis_CristianContext context)
        {
            _context = context;
        }

        public IList<Bilet> Bilet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bilet = await _context.Bilet
                .Include(b => b.Client)
                .Include(b => b.Obiectiv).ToListAsync();
        }
    }
}
