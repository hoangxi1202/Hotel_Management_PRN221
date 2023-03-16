using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhanNhatHoangRazorPages.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Username { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Username= HttpContext.Session.GetString("username");
                return Page();
            }
        }

        public IActionResult OnGetLogout()
        {          
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
