﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ass2_PRN221.Data;
using Ass2_PRN221.Models;

namespace Ass2_PRN221.Pages.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly Ass2_PRN221.Data.Ass2_PRN221Context _context;

        public IndexModel(Ass2_PRN221.Data.Ass2_PRN221Context context)
        {
            _context = context;
        }

        public IList<Ass2_PRN221.Models.Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Supplier != null)
            {
                Supplier = await _context.Supplier.ToListAsync();
            }
        }
    }
}
