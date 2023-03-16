using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.ManageStaff
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        public List<staff> Room { get;set; }
      
        public async Task<IActionResult> OnGetAsync()
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("1"))
            {

                Room = staf.GetAllstaff();
                return Page();
            }
            return RedirectToPage("/Errors");
        }


        public IActionResult OnGetLog()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }


    }
}
