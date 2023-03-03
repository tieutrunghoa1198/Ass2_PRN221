using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ass2_PRN221.Data;
using Ass2_PRN221.Models;

namespace Ass2_PRN221.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly Ass2_PRN221.Data.Ass2_PRN221Context _context;

        public DetailsModel(Ass2_PRN221.Data.Ass2_PRN221Context context)
        {
            _context = context;
        }

      public Ass2_PRN221.Models.Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
