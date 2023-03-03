using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace Ass2_PRN221.Pages.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        private readonly Ass2_PRN221.Data.Ass2_PRN221Context _context;

        public IndexModel(Ass2_PRN221.Data.Ass2_PRN221Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            /*if (!ModelState.IsValid)
              {
                  Console.WriteLine(Supplier.Address + " asdasd");
                  return Page();
              }*/

            var acc = _context.Account.SingleOrDefault(e => e.UserName == username);
            
            if (acc.Password.ToLower().Equals(password))
            {
                HttpContext.Session.SetString("account", JsonConvert.SerializeObject(acc));
                return Redirect("/App/");
            } else return RedirectToPage("./../Error");
            


        }
    }
}
