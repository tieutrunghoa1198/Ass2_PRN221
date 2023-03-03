using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ass2_PRN221.Data;
using Ass2_PRN221.Models;

namespace Ass2_PRN221.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly Ass2_PRN221.Data.Ass2_PRN221Context _context;

        public EditModel(Ass2_PRN221.Data.Ass2_PRN221Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Ass2_PRN221.Models.Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account =  await _context.Account.FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.AccountID))
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

        private bool AccountExists(int id)
        {
          return _context.Account.Any(e => e.AccountID == id);
        }
    }
}
