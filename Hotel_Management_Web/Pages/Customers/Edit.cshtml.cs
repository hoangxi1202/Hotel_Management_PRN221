using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Error");
            }
            else if (role.Equals("3"))
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
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                return RedirectToPage("/Error");
            }
            else if (role.Equals("3"))
            {
                //if (!ModelState.IsValid)
                //{
                //    return Page();
                //}

                try
                {
                    cus.UpdateCustomer(Customer);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                
            }
            return RedirectToPage("./Details", new { id = Customer.CustomerId });
        }

    }
}

