using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using DataAccess.Repository;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class EditModel : PageModel
    {
        private readonly IBookingDetailRepository bookingDetailRepository = new BookingDetailRepository();

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }
        public List<Item> cart { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            BookingDetail = cart[Int32.Parse(id)].BookingDetail;
            Id = cart[Int32.Parse(id)].Id;
            if (BookingDetail == null)
            {
                return NotFound();
            }
            return Page();
        }

        

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            cart[Id].BookingDetail.EndDate = BookingDetail.EndDate;
            cart[Id].BookingDetail.StartDate = BookingDetail.StartDate;
            DateTime ngaymuon = BookingDetail.StartDate;
            DateTime ngaytra = BookingDetail.EndDate;
            TimeSpan Time = ngaytra - ngaymuon;
            int TongSoNgay = Time.Days;
            
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //bookingDetailRepository.Update(BookingDetail);



            return RedirectToPage("./Index");
        }

        
    }
}
