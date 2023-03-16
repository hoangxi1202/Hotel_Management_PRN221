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

namespace Hotel_Management_Web.Pages.Customers
{
    public class DetailsModel : PageModel
    {

        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string cont = HttpContext.Session.GetString("username");
            string Id = HttpContext.Session.GetString("role");

            if (id == null)
            {
                return RedirectToPage("/Error");
            }
            else if (Id.Equals("3"))
            {
                if (id == null)
                {
                    return NotFound();
                }


                Customer = cus.GetCustomerbyId(id);

                if (Customer == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return RedirectToPage("/Errors");
        }
    }
}
