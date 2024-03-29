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

    public partial class BookingRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookingRequest()
        {
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter booking Date")]
        [DisplayFormat(DataFormatString = "{0:ddd, MM/dd/yyyy}")]
        public System.DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter booking Time")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Please enter how many person will come")]
        public int Persons { get; set; }

        [Required(ErrorMessage = "Please enter valid email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter valid telephone number")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Telephone { get; set; }
        public string Note { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd, MM/dd/yyyy}")]
        public System.DateTime TransactionDate { get; set; }
        public Nullable<int> BookingStatus { get; set; }
        public string ReviewCode { get; set; }
        public Nullable<int> RealTimeStart { get; set; }
        public Nullable<int> RealTimeEnd { get; set; }

        [Required(ErrorMessage = "Please enter Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public Nullable<int> BranchTableId { get; set; }

        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
