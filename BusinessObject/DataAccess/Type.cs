using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Type
    {
        public Type()
        {
            Rooms = new HashSet<Room>();
        }
        [Required(ErrorMessage = "TypeId is required")]
        [Display(Name = "TypeId")]
        [RegularExpression("^CA\\d{4,}$", ErrorMessage = "Not correct format BookingId")]
        public string TypeId { get; set; }
        [Required(ErrorMessage = "NameType is required")]
        [Display(Name = "NameType")]
       
        public string NameType { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [Range(0, 1, ErrorMessage = "0 - 1")]
        public int Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
