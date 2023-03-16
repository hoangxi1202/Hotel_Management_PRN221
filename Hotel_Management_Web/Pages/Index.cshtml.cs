using BusinessObject.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

    
        public string Role { get; set; }
        public string Msg { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToPage("Hotels/Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {            
                if (staf.checkAdminLogin(Email, Password) != null)
                {
                    HttpContext.Session.SetString("role", "1");

                    HttpContext.Session.SetString("username", Email);
                    string ap = HttpContext.Session.GetString("username");
                    //     return RedirectToPage("/Welcome");
                    return RedirectToPage("./ManageStaff/Index");

                }
                else if (staf.GetEmailStaffbyLogins(Email, Password) != null)
                {
                    HttpContext.Session.SetString("role", "2");
                    HttpContext.Session.SetString("id", staf.GetEmailStaffbyLogins(Email, Password).StaffId);
                    HttpContext.Session.SetString("hotelId", staf.GetEmailStaffbyLogins(Email, Password).HotelId);
                HttpContext.Session.SetString("username", Email);
                    return RedirectToPage("/Staffs/Index");
                }
                else if (cus.GetEmailStaffbyLogins(Email, Password) != null)
                {
                    HttpContext.Session.SetString("role", "3");
                HttpContext.Session.SetString("id", cus.GetEmailStaffbyLogins(Email, Password).CustomerId);
                HttpContext.Session.SetString("username", Email);

                    return RedirectToPage("/Hotels/Index");

                }
                else
                {
                    Msg = "Invalid";
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
