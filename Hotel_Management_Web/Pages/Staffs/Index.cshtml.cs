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

namespace Hotel_Management_Web.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        public List<staff> staff { get;set; }

        public IActionResult OnGet()
        {
            string cont = HttpContext.Session.GetString("username");
         
            staff = staf.Searchingstaff(cont);
            return Page();
           
        }
    
            public IActionResult OnGetLog()
        {
         
            HttpContext.Session.Clear();

            return RedirectToPage("/Welcome");
        }
    }
}
