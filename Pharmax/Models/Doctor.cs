using System.ComponentModel.DataAnnotations;

namespace Pharmax.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Name")]
        public string DocName { get; set; }
        [Required(ErrorMessage = "Email Address is required!")]
        
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string DocEmail { get; set; }
        [Required(ErrorMessage = "Phone Number is required!")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Entered phone number format is not valid.")]
        public double DocPhnNum { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        public string DocPassword { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        [Display(Name = "Address")]
        public string DocAddress { get; set; }
        public string Role { get; set; }

    }
}
