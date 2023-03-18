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
       
        public string Role { get; set; }
        public List<staff> staff { get;set; }

        public IActionResult OnGet()
        {

            string cont = HttpContext.Session.GetString("username");
            string Role = HttpContext.Session.GetString("role");

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Welcome");
            }
            else if (!Role.Equals("2") || !Role.Equals("1"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Role.Equals("2"))
            {
                staff = staf.Searchingstaff(cont);
                return Page();
            }else if(Role.Equals("1"))
            {
                staff = staf.GetAllstaff();
                return Page();
            }
            return RedirectToPage("/Errors");
        }
    
            public IActionResult OnGetLog()
        {
         
            HttpContext.Session.Clear();

            return RedirectToPage("/Welcome");
        }
    }
}
