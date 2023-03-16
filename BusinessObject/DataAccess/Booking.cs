using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }
        [Required(ErrorMessage = "BookingId is required")]
        [Display(Name = "BookingId")]
        [RegularExpression("^BO\\d+$\r\n", ErrorMessage = "Not correct format BookingId")]
        public string BookingId { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        [Display(Name = "CustomerId")]
        //[RegularExpression("^CU\\d+$\r\n", ErrorMessage = "Not correct format CustomerId")]
        public string CustomerId { get; set; }

        
        public string HotelID { get; set; }

        [Required(ErrorMessage = "CreateDate is required")]
        [Display(Name = "CreateDate")]   
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "TotalPrice is required")]
        [Display(Name = "TotalPrice")]

        public decimal? TotalPrice { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [Range(0, 1, ErrorMessage = "0 - 1")]
        public int Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
