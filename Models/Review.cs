//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndoRestaurant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter menu rating")]
        public int Menu { get; set; }

        [Required(ErrorMessage = "Please enter place rating")]
        public int Place { get; set; }

        [Required(ErrorMessage = "Please enter service rating")]
        public int Service { get; set; }

        [Required(ErrorMessage = "Please enter booking process rating")]
        public int BookingProcess { get; set; }

        [Required(ErrorMessage = "Please enter place your comment")]
        public string Comment { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd, MM/dd/yyyy}")]
        public System.DateTime ReviewDate { get; set; }
        public int BranchId { get; set; }
        public int BookingRequestId { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual BookingRequest BookingRequest { get; set; }
    }
}