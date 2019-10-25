using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndoRestaurant.Models
{
    public class ScheduledBookingViewModels
    {
        public int Id { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:ddddd, dd MMM yyyy}")]
        public System.DateTime Date { get; set; }
        public int Time { get; set; }
        [Required(ErrorMessage = "Please enter how many person will come")]
        public int Persons { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Note { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddddd, dd MMM yyyy}")]
        public System.DateTime TransactionDate { get; set; }
        public Nullable<int> BookingStatus { get; set; }
        public Nullable<int> RealTimeStart { get; set; }
        public Nullable<int> RealTimeEnd { get; set; }
        public Nullable<int> BranchTableId { get; set; }

        [Display(Name = "Table Number")]
        public string TableNo { get; set; }
        public int Capacity { get; set; }
    }
}