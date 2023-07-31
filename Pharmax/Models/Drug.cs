using System.ComponentModel.DataAnnotations;

namespace Pharmax.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        [Required(ErrorMessage = "Name is requierd!")]
        [Display(Name = "Name")]
        public string DrugName { get; set; }
        [Required(ErrorMessage = "Price is requierd!")]
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Expiry date is requierd!")]
        [Display(Name = "Expiry Date")]
        public DateTime ExpDate { get; set; }
        [Required(ErrorMessage = "Stock is requierd!")]
        [Display(Name = "Stock")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Stock { get; set; }
        public string Image { get; set; }
    }
}
