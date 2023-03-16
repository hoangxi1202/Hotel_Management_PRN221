using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.ManageStaff
{
    public class CreateModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();
        public IList<staff> staffs { get; set; }

        public IActionResult OnGet()
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null ||
               HttpContext.Session.GetString("password") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Id.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("1"))
            {

                return Page();
            }
            return RedirectToPage("/Errors");
        }

        [BindProperty]
        public staff Room { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
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
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                staf.AddNew(Room);
                return RedirectToPage("./Index");
            }
            return RedirectToPage("/Errors");
        }
    }
}
