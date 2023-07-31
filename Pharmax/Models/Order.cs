using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pharmax.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Date is requierd!")]
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }
        public bool IsPickedUp { get; set; } = false;
        [Required(ErrorMessage = "Amount is requierd!")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        public int Count { get; set; }
        public int DoctorId { get; set; }
       // public int AdminId { get; set; }
        public int DrugId { get; set; }

        [ValidateNever]
        public Doctor Doctor { get; set; }
       // [ValidateNever]
       // public Admin Admin { get; set; }
        [ValidateNever]
        public Drug Drug { get; set; }
    }
}
