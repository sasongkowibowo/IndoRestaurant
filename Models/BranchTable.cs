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

    public partial class BranchTable
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter table number")]
        public string TableNo { get; set; }

        [Required(ErrorMessage = "Please enter capacity")]
        public int Capacity { get; set; }
        public int BranchId { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
