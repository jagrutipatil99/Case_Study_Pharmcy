using System.ComponentModel.DataAnnotations;

namespace Pharmax.Models
{
    public class LoginDetails
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
        
    }
}
