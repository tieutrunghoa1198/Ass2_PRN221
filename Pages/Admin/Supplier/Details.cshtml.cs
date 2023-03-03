using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Ass2_PRN221.Data.Ass2_PRN221Context _context;

        public DetailsModel(Ass2_PRN221.Data.Ass2_PRN221Context context)
        {
            _context = context;
        }

      public Ass2_PRN221.Models.Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }
            else 
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}
