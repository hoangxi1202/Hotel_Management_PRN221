using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class BookingDetail
    {
        [Required(ErrorMessage = "BookingDetailId is required")]
        [Display(Name = "BookingDetailId")]
        [RegularExpression("^BD\\d+$\r\n", ErrorMessage = "Not correct format BookingDetailId")]
        public string BookingDetailId { get; set; }
        [Required(ErrorMessage = "BookingId is required")]
        [Display(Name = "BookingId")]
        [RegularExpression("^BO\\d+$\r\n", ErrorMessage = "Not correct format BookingId")]
        public string BookingId { get; set; }
        [Required(ErrorMessage = "RoomId is required")]
        [Display(Name = "RoomId")]
        [RegularExpression("^CA\\d{4,}$", ErrorMessage = "Not correct format RoomId")]
        public string RoomId { get; set; }
        [Required(ErrorMessage = "StartDate is required")]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "EndDate is required")]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Price")]
        
        public decimal Price { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
    }
}
